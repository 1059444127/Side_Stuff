namespace ConsoleQuest.Skills
{
    using System;
    public struct SkillDamage
    {
        public SkillDamage(DamageType typeOfAttack, int returnDamage)
            :this()
        {
            this.AttackType = typeOfAttack;
            this.Damage = returnDamage;
        }

        public DamageType AttackType { get; set; }

        public int Damage { get; set; }
    }
}
