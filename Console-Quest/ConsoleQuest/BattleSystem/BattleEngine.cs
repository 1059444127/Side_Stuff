namespace ConsoleQuest.BattleSystem
{
    using ConsoleQuest.Characters;
using ConsoleQuest.Skills;
using System;
using System.Linq;

    public class BattleEngine
    {
        private Party playerParty;
        private Party enemyParty;

        private int playerAbilitiesUsed = 0;
        private int enemyCharacterIndex = 0;
        private bool playerTurn;

        public BattleEngine(Party playerParty, Party enemyParty)
        {
            this.PlayerParty = playerParty;
            this.EnemyParty = enemyParty;
            this.playerTurn = true;
        }

        public Party PlayerParty
        {
            get
            {
                return this.playerParty;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Player party cannot be null!");
                }

                this.playerParty = value;
            }
        }

        public Party EnemyParty
        {
            get
            {
                return this.enemyParty;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Enemy party cannot be null!");
                }

                this.enemyParty = value;
            }
        }

        public void NextBattle(Combatant target, Skill ability)
        {
            while (this.PlayerParty.IsAlive && this.EnemyParty.IsAlive)
            {
                if (this.playerTurn)
                {

                }
            }
        }

        private void UpdateAfterPlayerAbility()
        {
            this.playerAbilitiesUsed++;
        }
    }
}
