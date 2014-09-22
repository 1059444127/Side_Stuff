using ConsoleQuest.Characters;
using ConsoleQuest.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ConsoleQuestGUI
{
    /// <summary>
    /// Interaction logic for PlayerAbilities.xaml
    /// </summary>
    public partial class PlayerAbilities : Window
    {
        public PlayerAbilities(Combatant character)
        {
            InitializeComponent();
            this.Character = character as PlayerControllable;
            this.Abilities.ItemsSource = this.Character.AvailableSkills;
            this.Title = String.Format("{0}'s abilities", this.Character.Name);
        }

        public PlayerControllable Character { get; set; }

        private void SelectSkill_Click(object sender, RoutedEventArgs e)
        {
            if (this.Abilities.SelectedItem == null)
            {
                MessageBox.Show("You must select a skill!");
                return;
            }

            BattleScreen battleScreen = null;

            foreach (var window in Application.Current.Windows)
            {
                if (window is BattleScreen)
                {
                    battleScreen = window as BattleScreen;
                    break;
                }
            }

            battleScreen.SelectSkill(this.Abilities.SelectedItem as Skill);

            this.Close();
        }
    }
}
