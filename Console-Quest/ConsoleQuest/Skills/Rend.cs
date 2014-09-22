using System;

namespace ConsoleQuest.Skills
{
    public class Rend : Skill, IAppliesStatusEffect
    {
        private const string SkillName = "Rend";
        private const string SkillDescription = "A swiping attack that causes bleeding on the target.";
        private const StatusEffects SkillEffect = StatusEffects.Bleeding;
        private const int SkillEffectDuration = 3;

        public Rend()
            :base(DamageType.Physical, SkillDescription, SkillName)
        {

        }

        public override SkillDamage DealDamage(int casterAttackDamage)
        {
            return new SkillDamage(DamageType.Physical, (int)(casterAttackDamage * 0.85));
        }

        public StatusEffect ApplyEffect()
        {
            return new StatusEffect(SkillEffect, SkillEffectDuration);
        }
    }
}
