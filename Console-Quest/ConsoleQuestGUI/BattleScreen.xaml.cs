using ConsoleQuest.BattleSystem;
using ConsoleQuest.Characters;
using ConsoleQuest.Skills;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ConsoleQuestGUI
{
    /// <summary>
    /// Interaction logic for BattleScreen.xaml
    /// </summary>
    public partial class BattleScreen : Window
    {
        private readonly int maximumPlayerTurns;
        private readonly int maximumEnemyTurns;
        private bool isPlayerTurn;
        private int playerTurns;
        private List<Combatant> availablePlayerCharacters;
        private List<Combatant> availableEnemyCharacters;
        private Combatant currentCharacter;
        private Combatant currentPlayerTarget;
        private Skill currentSelectedSKill;
        private List<Button> playerCharactersButtons;
        private List<Button> enemyCharactersButtons;

        public BattleScreen(Party playerParty, Party enemyParty)
        {
            InitializeComponent();
            this.PlayerParty = playerParty;
            this.EnemyParty = enemyParty;
            this.maximumPlayerTurns = this.PlayerParty.Count();
            this.maximumEnemyTurns = this.EnemyParty.Count();
            this.isPlayerTurn = true;
            this.playerTurns = 0;

            foreach (var member in this.PlayerParty)
            {
                (member as PlayerControllable).AbilityUsedEvent += OnPlayerAbilityUsed;
            }

            this.availablePlayerCharacters = this.PlayerParty.Where(x => x.CanAttack()).ToList();
            DetermineNextPlayerCharacter();

            this.playerCharactersButtons = new List<Button>()
            {
                this.PlayerPartyFirstButton,
                this.PlayerPartySecondButton,
                this.PlayerPartyThirdButton
            };

            this.enemyCharactersButtons = new List<Button>()
            {
                this.EnemyPartyFirstButton,
                this.EnemyPartySecondButton,
                this.EnemyPartyThirdButton
            };
        }

        public Party PlayerParty { get; private set; }

        public Party EnemyParty { get; private set; }

        public void SelectSkill(Skill skillToSelect)
        {
            this.currentSelectedSKill = skillToSelect;
        }

        // TODO: Implement ability selection logic.
        private void AbilitiesButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerAbilities abilities = new PlayerAbilities(this.currentCharacter);
            abilities.Owner = this;
            abilities.ShowDialog();

            foreach (var button in this.enemyCharactersButtons)
            {
                button.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void DetermineNextPlayerCharacter()
        {
            this.currentCharacter = this.availablePlayerCharacters.FirstOrDefault(x => x.CanAttack());
        }

        private void DetermineNextEnemyCharacter()
        {
            this.currentCharacter = this.availableEnemyCharacters.FirstOrDefault(x => x.CanAttack());
        }

        private void OnPlayerAbilityUsed()
        {
            this.playerTurns++;
        }

        // TODO: Make first parameter a collection, so the character UseAbility logic can check the targeting data.
        private void ManageInteraction(Combatant target, Skill skill)
        {
            if (this.isPlayerTurn)
            {
                if (this.currentCharacter != null)
                {
                    (this.currentCharacter as PlayerControllable).UseAbility(target, skill);
                }

                DetermineNextPlayerCharacter();

                if (this.currentCharacter == null || this.playerTurns >= this.maximumPlayerTurns)
                {
                    this.PlayerParty.UpdateParty();
                    this.isPlayerTurn = false;
                    this.playerTurns = 0;
                    this.availableEnemyCharacters = this.EnemyParty.Where(x => x.CanAttack()).ToList();
                    DetermineNextEnemyCharacter();
                }
            }
            else
            {
                if (this.currentCharacter != null)
                {
                    this.currentCharacter.DealDamage(target);
                }

                DetermineNextEnemyCharacter();

                if (this.currentCharacter == null)
                {
                    this.EnemyParty.UpdateParty();
                    this.isPlayerTurn = true;
                    this.availablePlayerCharacters = this.PlayerParty.Where(x => x.CanAttack()).ToList();
                    DetermineNextPlayerCharacter();
                }
            }
        }
    }
}
