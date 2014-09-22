using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace MusicSync
{
    /// <summary>
    /// Interaction logic for ToSyncWindow.xaml
    /// </summary>
    public partial class ToSyncWindow : Window
    {
        public ToSyncWindow(List<Track> tracksToSync, string title, string copyToFolder)
        {
            InitializeComponent();

            this.AvailableTracks = new ObservableCollection<Track>(tracksToSync);

            this.Tracks.ItemsSource = this.AvailableTracks;

            this.Title = title;
            this.Tracks.SelectAll();

            this.DestinationFolder = copyToFolder;
        }

        public ObservableCollection<Track> AvailableTracks { get; private set; }

        public string DestinationFolder { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedTracks = this.Tracks.SelectedItems;
            string destinationFolder = this.DestinationFolder;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                this.Worker_DoWork(selectedTracks, destinationFolder);
            });
        }

        private void Worker_DoWork(System.Collections.IList selectedTracks, string destinationFolder)
        {
            List<Track> uncopiedTracks = new List<Track>();
            Queue<Track> trackQueue = new Queue<Track>();
            foreach (var track in selectedTracks)
            {
                trackQueue.Enqueue(track as Track);
            }

            Dispatcher.Invoke((Action)delegate()
            {
                this.CopyProgressBar.Minimum = 0;
                this.CopyProgressBar.Value = 0;
                this.CopyProgressBar.Maximum = trackQueue.Count;
                this.Cursor = Cursors.Wait;
                this.CopyButton.IsEnabled = false;
            });

            while (trackQueue.Count > 0)
            {
                var track = trackQueue.Dequeue();

                string fullPath = destinationFolder + "\\" + track.Name;

                try
                {
                    File.Copy(track.Path, fullPath);
                }
                catch (Exception)
                {
                    MessageBox.Show(String.Format("Something went wrong while copying {0}", track.Name));
                    uncopiedTracks.Add(track);
                }

                Dispatcher.Invoke((Action)delegate()
                {
                    this.CopyProgressBar.Value++;
                });
            }

            Dispatcher.Invoke((Action)delegate()
            {
                this.AvailableTracks.Clear();
                foreach (var track in uncopiedTracks)
                {
                    this.AvailableTracks.Add(track);
                }

                this.Cursor = Cursors.Arrow;
                MessageBox.Show("File copy successful!");
                this.CopyButton.IsEnabled = true;
            });
        }
    }
}
