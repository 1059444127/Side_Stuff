namespace ConsoleQuest.Characters
{
    using System;

    public class Player : PlayerControllable, IScalable, IAttackable
    {
        protected const int StartingExperience = 100;
        protected const int StartingHitPoints = 500;
        protected const int StartingMoney = 10;
        protected const double ExperienceScaling = 1.4;

        public Player(string name, ConsoleColor color)
            : base(name, null, color)
        {
            this.Level = 1;
            this.Gold = StartingMoney;
            this.NeededXP = StartingExperience;
            this.TotalHitPoints = StartingHitPoints;
            this.CurrentHitPoints = this.TotalHitPoints;
            this.CurrentXP = 0;
        }

        public override int Level { get; protected set; }

        public int Gold { get; set; }

        public int NeededXP { get; private set; }

        public int CurrentXP { get; private set; }

        public virtual void LevelUp()
        {
            this.Level++;
            this.TotalHitPoints += 100;
            this.CurrentHitPoints = this.TotalHitPoints;
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
    }
}
