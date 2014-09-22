using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MusicSync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DiskDriveNames = new ObservableCollection<string>();

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    this.DiskDriveNames.Add(drive.Name);
                }
            }

            this.SmartphoneDrive.ItemsSource = this.DiskDriveNames;
            this.FlashDrive.ItemsSource = this.DiskDriveNames;

            this.Worker = new BackgroundWorker();
            this.Worker.WorkerReportsProgress = true;
            //this.Worker.DoWork += Worker_DoWork;
        }

        private BackgroundWorker Worker { get; set; }

        public string RadioButtonSelection { get; private set; }

        public ObservableCollection<string> DiskDriveNames { get; private set; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                this.RadioButtonSelection = button.Name;
            }
        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SmartphoneDrive.SelectedValue == null || this.FlashDrive.SelectedValue == null)
            {
                MessageBox.Show("Please select your smartphone and flash memory drives!", "Select drives", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string smartphoneDrivePath = this.SmartphoneDrive.SelectedValue.ToString();
            string flashDrivePath = this.FlashDrive.SelectedValue.ToString();
            string selectedRadioButton = this.RadioButtonSelection;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                this.Worker_DoWork(smartphoneDrivePath, flashDrivePath, selectedRadioButton);
            });
        }

        private void Worker_DoWork(string smartphoneDrivePath, string flashDrivePath, string radioButtonSelection)
        {            
            Dispatcher.Invoke((Action)delegate()
            {
                CurrentTaskProgress.IsIndeterminate = true;
                CurrentOperationStatus.Content = "Traversing Smartphone...";
            });

            var smartphoneTrackList = GetTrackListFromPath(smartphoneDrivePath);

            Dispatcher.Invoke((Action)delegate()
            {
                CurrentOperationStatus.Content = "Traversing Flash drive...";
            });

            var flashDriveTrackList = GetTrackListFromPath(flashDrivePath);

            Dispatcher.Invoke((Action)delegate()
            {
                CurrentOperationStatus.Content = "Idle";
                CurrentTaskProgress.IsIndeterminate = false;
            });

            List<Track> smartphoneToFlashList = new List<Track>();
            List<Track> flashToSmartphoneList = new List<Track>();

            string smartphoneMusicFolder;
            try
            {
                smartphoneMusicFolder = smartphoneTrackList.OrderByDescending(x => x.FileCount).FirstOrDefault().ToString();
            }
            catch (NullReferenceException)
            {
                smartphoneMusicFolder = smartphoneDrivePath + "\\Music\\";
            }

            string flashDriveMusicFolder;
            try
            {
                flashDriveMusicFolder = flashDriveTrackList.OrderByDescending(x => x.FileCount).FirstOrDefault().ToString();   
            }
            catch (NullReferenceException)
            {
                flashDriveMusicFolder = flashDrivePath + '\\';
            }

            Dispatcher.Invoke((Action)delegate()
            {
                if (radioButtonSelection == "RadioOne")
                {
                    smartphoneToFlashList.AddRange(GetMissingTracks(smartphoneTrackList, flashDriveTrackList));
                    SyncTracks(smartphoneToFlashList, "Smartphone to flash", flashDriveMusicFolder);
                }
                else if (radioButtonSelection == "RadioTwo")
                {
                    flashToSmartphoneList.AddRange(GetMissingTracks(flashDriveTrackList, smartphoneTrackList));
                    SyncTracks(flashToSmartphoneList, "Flash to Smartphone", smartphoneMusicFolder);
                }
                else
                {
                    smartphoneToFlashList.AddRange(GetMissingTracks(smartphoneTrackList, flashDriveTrackList));
                    flashToSmartphoneList.AddRange(GetMissingTracks(flashDriveTrackList, smartphoneTrackList));

                    SyncTracks(smartphoneToFlashList, "Smartphone to flash", flashDriveMusicFolder);
                    SyncTracks(flashToSmartphoneList, "Flash to Smartphone", smartphoneMusicFolder);
                }
            });
        }

        //TODO: Check for errors
        private List<Track> GetMissingTracks(List<Folder> fromList, List<Folder> toList)
        {
            if (fromList == null || toList == null)
            {
                throw new ArgumentNullException("Specified list cannot be null.");
            }

            var fromListTracks = new List<Track>();
            foreach (var folder in fromList)
            {
                fromListTracks.AddRange(folder.TrackList);
            }

            var toListTracks = new List<Track>();
            foreach (var folder in toList)
            {
                toListTracks.AddRange(folder.TrackList);
            }

            List<Track> missingTracks = new List<Track>();

            foreach (var track in fromListTracks)
            {
                if (!toListTracks.Contains(track))
                {
                    missingTracks.Add(track);
                }
            }

            return missingTracks;
        }

        private void SyncTracks(List<Track> listToSync, string deviceName, string destinationFolder)
        {
            ToSyncWindow syncWindow = new ToSyncWindow(listToSync, deviceName, destinationFolder);
            syncWindow.ShowDialog();
        }

        private List<Folder> GetTrackListFromPath(string startingPoint)
        {
            List<Folder> trackList = new List<Folder>();

            Stack<string> dfsStack = new Stack<string>();
            dfsStack.Push(startingPoint);

            while (dfsStack.Count > 0)
            {
                string currentDir = dfsStack.Pop();
                IEnumerable<string> availableTracks = null;

                try
                {
                    availableTracks = Directory.EnumerateFiles(currentDir, "*.mp3", SearchOption.TopDirectoryOnly);
                }
                catch(UnauthorizedAccessException)
                {
                    continue;
                }

                var currentTrackList = new List<Track>();

                foreach (var track in availableTracks)
                {
                    string trackPath = track;
                    string trackName = System.IO.Path.GetFileName(track);

                    currentTrackList.Add(new Track(trackName, trackPath));
                }

                if (currentTrackList.Count > 0)
                {
                    trackList.Add(new Folder(currentDir, currentTrackList));
                }

                var subDirs = Directory.EnumerateDirectories(currentDir);

                foreach (var dir in subDirs)
                {
                    dfsStack.Push(dir);
                }
            }

            return trackList;
        }
    }
}
