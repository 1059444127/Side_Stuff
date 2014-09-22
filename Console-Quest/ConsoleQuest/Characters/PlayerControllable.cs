using ConsoleQuest.BattleSystem;
using ConsoleQuest.Skills;
using System;

namespace ConsoleQuest.Characters
{
    public abstract class PlayerControllable : Combatant
    {
        public delegate void AbilityUsedHandler();

        public event AbilityUsedHandler AbilityUsedEvent;

        public PlayerControllable(string name, string description, ConsoleColor color) : base(name, description, color)
        {
        }

        public AttackLog UseAbility(IAttackable target, Skill skillToUse)
        {
            var attackResult = target.TakeDamage(skillToUse.DealDamage(this.AttackDamage));
            attackResult.AttackDetails = String.Format("{0} applies {1} on {2}", this.Name, skillToUse.Name, attackResult.AttackDetails);

            return attackResult;
        }

        protected void OnAbilityUsed()
        {
            if (this.AbilityUsedEvent != null)
            {
                this.AbilityUsedEvent();
            }
        }
    }
}