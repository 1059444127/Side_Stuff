namespace ConsoleQuest.Characters
{
    using ConsoleQuest.Skills;
    using System;

    public abstract class Ally : PlayerControllable, IScalable, IAttackable
    {

        private int level;

        public Ally(string name, string description, int playerLevel, int playerNeededXp)
            : base(name, description, ConsoleColor.Cyan)
        {
            this.Level = playerLevel;
            this.AttackDamage = 50 + (this.Level - 1) * 10;
            this.TotalHitPoints = 500 + (this.Level - 1) * 100;
            this.CurrentHitPoints = this.TotalHitPoints;
            this.NeededXP = playerNeededXp;
            this.CurrentXP = 0;
        }

        public override int Level
        {
            get
            {
                return this.level;
            }
            protected set
            {
                this.level = value;
            }
        }

        public int CurrentXP { get; private set; }

        public int NeededXP { get; private set; }

        public virtual void LevelUp()
        {
            this.Level++;
            this.TotalHitPoints += 100;
            this.CurrentHitPoints = this.TotalHitPoints;
            this.AttackDamage += 10;
            this.CurrentXP -= this.NeededXP;
            this.NeededXP = (int)(this.NeededXP * 1.4);
        }

        public virtual void AddXP(int experienceToAdd)
        {
            this.CurrentXP += experienceToAdd;
            if (this.CurrentXP >= this.NeededXP)
            {
                this.LevelUp();
            }
        }

        public override string ToString()
        {
            string result = string.Empty;

            if (this.IsAlive)
            {
                result = String.Format("Name: {0}. Level: {1}. HP: {2}/{3}. XP: {4}/{5}. Attack Damage: {6}.", this.Name, this.Level, this.CurrentHitPoints, this.TotalHitPoints, this.CurrentXP, this.NeededXP, this.AttackDamage);
            }
            else
            {
                result = String.Format("{0} - Dead.", this.Name);
            }

            return result;
        }
    }
}
