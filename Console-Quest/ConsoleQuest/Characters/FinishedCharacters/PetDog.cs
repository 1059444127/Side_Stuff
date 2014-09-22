namespace ConsoleQuest.Characters.FinishedCharacters
{
    using System;
    using ConsoleQuest.BattleSystem;
    using ConsoleQuest.Common;
    using ConsoleQuest.Skills;

    public class PetDog : Ally, IAttackable, IScalable
    {
        private const int StartingCriticalChance = 5;

        public PetDog(int playerLevel, int xpNeeded)
            :base("Doggy", "Your pet dog", playerLevel, xpNeeded)
        {
            this.CriticalStrikeChance = StartingCriticalChance + this.Level - 1;
            this.AvailableSkills.AddSkill(new BasicAttack(DamageType.Physical));
            this.AvailableSkills.AddSkill(new CriticalStrike());
        }

        public int CriticalStrikeChance { get; private set; }

        public override AttackLog DealDamage(IAttackable target)
        {
            if (!this.CanAttack())
            {
                return AttackLog.AttackFailed;
            }

            else if (target.IsAlive)
            {
                SkillDamage attackPower;
                AttackLog result;

                if (RandomGenerator.GetRandomValue(0, 101) <= this.CriticalStrikeChance)
                {
                    attackPower = this.AvailableSkills["critical strike"].DealDamage(this.AttackDamage);
                    result = target.TakeDamage(attackPower);
                    result.AttackDetails = String.Format("{0} scores a critical strike on {1}", this.Name, result.AttackDetails);
                }
                else
                {
                    attackPower = this.AvailableSkills["basic attack"].DealDamage(this.AttackDamage);
                    result = target.TakeDamage(attackPower);
                    result.AttackDetails = String.Format("{0} attacks {1}", this.Name, result.AttackDetails);
                }

                this.OnAbilityUsed();

                return result;
            }

            return AttackLog.AttackFailed;
        }

        public override void LevelUp()
        {
            this.CriticalStrikeChance++;
            base.LevelUp();
        }
    }
}
