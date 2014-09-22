using System;
namespace ConsoleQuest.Skills
{
    public abstract class Skill
    {
        public Skill(DamageType damage, string description, string name)
        {
            this.DamageType = damage;
            this.Description = description;
            this.Name = name;
        }

        public DamageType DamageType { get; private set; }

        public string Description { get; private set; }

        public string Name { get; private set; }

        public abstract SkillDamage DealDamage(int casterAttackDamage);
    }
}
