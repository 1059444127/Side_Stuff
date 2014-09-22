namespace ConsoleQuest.Characters.FinishedCharacters
{
    using System;
    using System.Linq;
    using ConsoleQuest.BattleSystem;
    using ConsoleQuest.Common;
    using ConsoleQuest.Skills;

    public class Wolf : Enemy, IAttackable
    {
        private const double StartingCriticalChance = 5;
        private const int StartHP = 500;
        private const int StartAttackDamage = 50;

        private const string WolfDescription = "A wolf as black as night, with razor-sharp fangs. Common in forest areas. A formiddable foe.";

        public Wolf()
            :this(2)
        {

        }

        public Wolf(int partyLevel)
            :base(RandomGenerator.GetRandomWolfName(), WolfDescription, partyLevel)
        {
            this.TotalHitPoints = StartHP + ((this.Level - 1) * 100);
            this.CurrentHitPoints = TotalHitPoints;
            this.XpYield = (this.TotalHitPoints / 10) + 10;
            this.AttackDamage = StartAttackDamage + (this.Level - 1) * 10;
            this.CriticalStrikeChance = StartingCriticalChance + (this.Level * 0.5);
            this.AvailableSkills.AddSkill(new BasicAttack(DamageType.Physical));
            this.AvailableSkills.AddSkill(new CriticalStrike());
            this.AvailableSkills.AddSkill(new Rend());
        }

        public double CriticalStrikeChance { get; private set; }

        public override AttackLog DealDamage(IAttackable target)
        {
            if (!this.CanAttack())
            {
                return AttackLog.AttackFailed;
            }

            if (target.IsAlive)
            {
                SkillDamage attackPower;
                AttackLog result;
                if (RandomGenerator.GetRandomValue(0, 100) % 2 == 0)
                {
                    var specialSkills = this.AvailableSkills.Where(x => !(x is BasicAttack) && !(x is CriticalStrike)).ToList();

                    var skillToUse = specialSkills[RandomGenerator.GetRandomValue(0, specialSkills.Count)];

                    var appliesStatusEffect = skillToUse as IAppliesStatusEffect;
                    if (appliesStatusEffect != null)
                    {
                        target.AddStatusEffect(appliesStatusEffect.ApplyEffect());
                    }

                    attackPower = skillToUse.DealDamage(this.AttackDamage);
                    result = target.TakeDamage(attackPower);
                    result.AttackDetails = string.Format("{0} applies {1} on {2}", this.Name, skillToUse.Name, result.AttackDetails);

                }
                else
                {
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
                }

                return result;
            }
            else
            {
                return AttackLog.AttackFailed;
            }
        }
    }
}
