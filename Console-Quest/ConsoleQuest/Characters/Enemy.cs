namespace ConsoleQuest.Characters
{
    using System;
    public abstract class Enemy : Combatant, IAttackable
    {
        public Enemy(string name, string description, int partyLevel)
            : base(name, description, ConsoleColor.Red)
        {
            this.Level = partyLevel;
        }

        /// <summary>
        /// Returns the XP gain from defeating this enemy.
        /// </summary>
        public int XpYield { get; protected set; }

        public override string ToString()
        {
            string result = string.Empty;
            if (this.IsAlive)
            {
                result = String.Format("Name: {0}. Level: {1}. HP: {2}/{3}. XP yield: {4}. Attack Damage: {5}.", this.Name, this.Level, this.CurrentHitPoints, this.TotalHitPoints, this.XpYield, this.AttackDamage);
            }
            else
            {
                result = String.Format("{0} - Dead.", this.Name);
            }

            return result;
        }
    }
}
