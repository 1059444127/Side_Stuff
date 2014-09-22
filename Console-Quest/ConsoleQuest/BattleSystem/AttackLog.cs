namespace ConsoleQuest.BattleSystem
{
    using System;
    public struct AttackLog
    {
        public static AttackLog AttackFailed
        {
            get
            {
                return new AttackLog(false, string.Empty);
            }
        }

        private bool attackPassed;

        private string attackDetails;

        /// <summary>
        /// Provides details about the current attack.
        /// </summary>
        /// <param name="attackPassed">Specifies if the attack is succesful.</param>
        /// <param name="attackDetails">Provides details about the attack.</param>
        public AttackLog(bool attackPassed, string attackDetails)
            :this()
        {
            this.AttackPassed = attackPassed;
            this.AttackDetails = attackDetails;
        }

        public bool AttackPassed
        {
            get
            {
                return this.attackPassed;
            }
            set
            {
                this.attackPassed = value;
            }
        }

        public string AttackDetails
        {
            get
            {
                return this.attackDetails;
            }
            set
            {
                this.attackDetails = value;
            }
        }

        public override string ToString()
        {
            return this.AttackDetails;
        }
    }
}
