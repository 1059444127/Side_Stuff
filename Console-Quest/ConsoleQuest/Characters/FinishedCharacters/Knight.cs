namespace ConsoleQuest.Characters.FinishedCharacters
{
    using System;
    using System.Linq;
    using ConsoleQuest.BattleSystem;
    using ConsoleQuest.Skills;
    using ConsoleQuest.Common;

    public class Knight : Ally, IAttackable, IScalable
    {
        private const int StartingArmorNegation = 12;

        public Knight(int playerLevel, int neededXP)
            :base("Gary", "A knight you found in the woods", playerLevel, neededXP)
        {

            this.ArmorNegation = StartingArmorNegation + this.Level;
            this.AvailableSkills.AddSkill(new BasicAttack(DamageType.Physical));
            this.AvailableSkills.AddSkill(new ShieldBash());
        }

        public int ArmorNegation { get; private set; }

        public override void LevelUp()
        {
            this.ArmorNegation++;
            base.LevelUp();
        }

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

                if (RandomGenerator.GetRandomValue(0, 101) % 2 == 0)
                {
                    var specialSkills = this.AvailableSkills.Where(x => !(x is BasicAttack)).ToList();
 
                    var skillToUse = specialSkills[RandomGenerator.GetRandomValue(0, specialSkills.Count)];

                    var appliesStatusEffect = skillToUse as IAppliesStatusEffect;
                    if (appliesStatusEffect != null)
                    {
                        target.AddStatusEffect(appliesStatusEffect.ApplyEffect());
                    }

                    attackPower = skillToUse.DealDamage(this.AttackDamage);
                    result = target.TakeDamage(attackPower);
                    result.AttackDetails = string.Format("{0} applies {1} on {2}", this.Name, skillToUse.Name, result.AttackDetails);

                    this.OnAbilityUsed();

                    return result;
                }
                else
                {
                    this.OnAbilityUsed();

                    return base.DealDamage(target);
                }
            }

            return AttackLog.AttackFailed;
        }

        public override AttackLog TakeDamage(SkillDamage damage)
        {
            if (damage.AttackType == DamageType.Physical)
            {
                double armorNegationPercentage = this.ArmorNegation / 100.0;
                damage.Damage -= (int)(damage.Damage * armorNegationPercentage);
            }
            return base.TakeDamage(damage);
        }
    }
}
