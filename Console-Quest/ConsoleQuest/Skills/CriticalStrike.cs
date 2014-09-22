namespace ConsoleQuest.Skills
{
    using ConsoleQuest.Common;
    public class CriticalStrike : Skill
    {
        private const string CriticalStrikeName = "Critical Strike";
        private const string CriticalStrikeDescription = "A critical hit on the target that deals double damage.";

        public CriticalStrike()
            :base(DamageType.Physical, CriticalStrikeDescription, CriticalStrikeName)
        {
            

        }

        public override SkillDamage DealDamage(int casterAttackDamage)
        {
            int resultingDamage = RandomGenerator.GetRandomValue(casterAttackDamage - 1, casterAttackDamage + 2) * 2;
            return new SkillDamage(this.DamageType, resultingDamage);
        }
    }
}
