namespace ConsoleQuest.Skills
{
    public class ShieldBash : Skill, IAppliesStatusEffect
    {
        private const string SkillName = "Shield Bash";
        private const string SKillDescription = "A shield bash that deals minor damage and stuns the target.";
        private const StatusEffects SkillEffect = StatusEffects.Stunned;
        private const int SkillEffectDuration = 2;

        public ShieldBash()
            :base(DamageType.Physical, SKillDescription, SkillName)
        {
        }

        public override SkillDamage DealDamage(int casterAttackDamage)
        {
            return new SkillDamage(Skills.DamageType.Physical, (int)(casterAttackDamage * 0.20));
        }

        public StatusEffect ApplyEffect()
        {
            return new StatusEffect(SkillEffect, SkillEffectDuration);
        }
    }
}
