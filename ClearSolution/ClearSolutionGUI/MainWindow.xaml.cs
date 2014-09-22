using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace ClearSolutionGUI
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

        private void bOpenFileDialog_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openDialog = new FolderBrowserDialog();
            openDialog.ShowNewFolderButton = true;
            DialogResult userClickedOk = openDialog.ShowDialog();

            if (userClickedOk.ToString() == "OK")
            {
                tbResults.Text = openDialog.SelectedPath;
            }
        }

        private void clearSolution_Click(object sender, RoutedEventArgs e)
        {
            bool directoryError = false;
            string path = tbResults.Text;
            if (path != null && Directory.Exists(path) == true)
            {
                int deleteCount = 0;
                string[] allProjects = Directory.GetDirectories(path);
                foreach (var folder in allProjects)
                {
                    StringBuilder binPath = new StringBuilder(folder);
                    StringBuilder objPath = new StringBuilder(folder);

                    binPath.Append(@"\bin");
                    objPath.Append(@"\obj");

                    if (Directory.Exists(binPath.ToString()) == true && Directory.Exists(objPath.ToString()) == true)
                    {
                        Directory.Delete(binPath.ToString(), true);
                        Directory.Delete(objPath.ToString(), true);
                        deleteCount++;
                    }

                }
                if (deleteCount > 0)
                {
                    System.Windows.MessageBox.Show("Решението е изчистено успешно!");
                    System.Diagnostics.Process.Start(tbResults.Text);
                }
                else
                {
                    System.Windows.MessageBox.Show("Решението няма нужда от чистене!");
                    System.Diagnostics.Process.Start(tbResults.Text);
                }

                // Zip the contents of the directory
                var desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                int lastSlashIndex = path.LastIndexOf('\\');
                var zipFileName = path.Substring(lastSlashIndex) + ".zip";

                ZipFile.CreateFromDirectory(path, desktopDir + zipFileName);
            }
            else
            {
                System.Windows.MessageBox.Show("Невалидна директория!");
            }
        }
    }
}
