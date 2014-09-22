using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using TransportSchedulesClasses;

namespace RouteProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string RadioButtonSelection { get; set; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                this.RadioButtonSelection = button.Name;
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                this.FilePath.Text = openFileDialog.FileName;
            }
        }

        private void ProcessFileButton_Click(object sender, RoutedEventArgs e)
        {
            string routesFilePath = this.FilePath.Text;
            string timetablesFilePath = this.TimetablePath.Text;

            string routesDirPath = string.Empty;
            string timetableDirPath = string.Empty;

            if (!string.IsNullOrWhiteSpace(routesFilePath))
            {
                routesDirPath = System.IO.Path.GetDirectoryName(routesFilePath);
            }

            if (!string.IsNullOrWhiteSpace(timetablesFilePath))
            {
                timetableDirPath = System.IO.Path.GetDirectoryName(timetablesFilePath);
            }

            if (this.RadioButtonSelection == "RadioOne")
            {
                if (string.IsNullOrWhiteSpace(routesFilePath))
                {
                    MessageBox.Show("You must select a valid file!");
                }

                if (ProcessRoutes(routesFilePath))
                {
                    MessageBox.Show("Succesfully extracted information.");

                    Process.Start(routesDirPath + "\\Processed Routes");
                }
                else
                {
                    MessageBox.Show("Unsuccesfully extracted information");
                }
            }
            else if (this.RadioButtonSelection == "RadioTwo")
            {
                if (string.IsNullOrWhiteSpace(timetablesFilePath))
                {
                    MessageBox.Show("You must select a valid file!");
                }

                if (ProcessTimetables(timetablesFilePath))
                {
                    MessageBox.Show("Succesfully extracted information.");

                    Process.Start(timetableDirPath + "\\Timetables");
                }
                else
                {
                    MessageBox.Show("Unsuccesfully extracted information");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(routesFilePath) || string.IsNullOrWhiteSpace(timetablesFilePath))
                {
                    MessageBox.Show("You must select a valid file!");
                }

                if (ProcessRoutes(routesFilePath) && ProcessTimetables(timetablesFilePath))
                {
                    MessageBox.Show("Succesfully extracted information.");

                    Process.Start(routesDirPath + "\\Processed Routes");
                    Process.Start(timetableDirPath + "\\Timetables");
                }
                else
                {
                    MessageBox.Show("Unsuccesfully extracted information");
                }
            }
        }

        private void OpenTimetable_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".xml";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                this.TimetablePath.Text = openFileDialog.FileName;
            }
        }

        private bool ProcessTimetables(string fullPath)
        {
            try
            {
                TimetableProcessing.ProcessTimetable(fullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool ProcessRoutes(string fullPath)
        {
            try
            {
                TransportSchedulesClasses.RouteProcessing.ProcessRoutes(fullPath);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Missing filepath!");
                return false;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
    }
}
