namespace ConsoleQuest.Characters
{
    using ConsoleQuest.BattleSystem;
    using ConsoleQuest.Skills;
    public interface IAttackable
    {
        AttackLog DealDamage(IAttackable target);

        AttackLog TakeDamage(SkillDamage damage);

        bool IsAlive { get; }

        void AddStatusEffect(StatusEffect effect);
    }
}
