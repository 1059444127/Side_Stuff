using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

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

            this.AvailableTracks = new ObservableCollection<Track>();
            
            Tracks.ItemsSource = this.AvailableTracks;

            this.DiskDriveNames = new ObservableCollection<string>();

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    this.DiskDriveNames.Add(drive.Name);
                }
            }

            this.DiskDrives.ItemsSource = this.DiskDriveNames;

            this.DiskDrives.SelectedIndex = 0;
        }

        public ObservableCollection<Track> AvailableTracks { get; set; }

        public ObservableCollection<string> DiskDriveNames { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in this.Tracks.SelectedItems)
            {
                MessageBox.Show((item as Track).Name);
            }
        }
    }
}
