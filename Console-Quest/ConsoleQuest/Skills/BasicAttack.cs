namespace ConsoleQuest.Skills
{
    using System;
    using ConsoleQuest.Common;
    public class BasicAttack : Skill
    {
        private const string BasicAttackName = "Basic attack";
        private const string BasicAttackDescription = "A basic attack";

        public BasicAttack(DamageType damage)
            :base(damage, BasicAttackDescription, BasicAttackName)
        {
            
        }

        public override SkillDamage DealDamage(int casterAttackDamage)
        {
            return new SkillDamage(this.DamageType, RandomGenerator.GetRandomValue(casterAttackDamage - 8, casterAttackDamage + 11));
        }
    }
}
