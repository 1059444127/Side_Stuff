using ConsoleQuest.BattleSystem;
using ConsoleQuest.Characters.FinishedCharacters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleQuestGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BattleScreen battleScreen = new BattleScreen(new Party(new Knight(3, 150), new PetDog(3, 150)), new Party());
            this.Close();
            battleScreen.Show();
        }

        private void AbilitiesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
