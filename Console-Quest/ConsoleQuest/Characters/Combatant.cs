namespace ConsoleQuest.Characters
{
    using ConsoleQuest.BattleSystem;
    using ConsoleQuest.Common;
    using ConsoleQuest.Skills;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Combatant : Entity, IAttackable, ITargetable
    {
        private int level;
        private int currentHitPoints;
        private SkillCollection availableSkills;
        private ICollection<StatusEffect> activeEffects;
        private ICollection<Skill> buffs;
        private ICollection<Skill> debuffs;

        public Combatant(string name, string description, ConsoleColor color)
            : base(name, description)
        {
            this.Color = color;
            this.IsAlive = true;
            this.AvailableSkills = new SkillCollection();
            this.activeEffects = new List<StatusEffect>();
            this.buffs = new List<Skill>();
            this.debuffs = new List<Skill>();
        }

        /// <summary>
        /// Holds the Color associated with this character
        /// </summary>
        public ConsoleColor Color { get; protected set; }

        /// <summary>
        /// Gets the current level of the character. Can be overloaded.
        /// </summary>
        public virtual int Level
        {
            get
            {
                return this.level;
            }
            protected set
            {
                if (value <= 1)
                {
                    this.level = RandomGenerator.GetRandomValue(1, 3);
                }
                else
                {
                    this.level = RandomGenerator.GetRandomValue(value - 1, value + 2);
                }
            }
        }

        /// <summary>
        /// Returns the attack damage power of this character. Can be overloaded.
        /// </summary>
        public virtual int AttackDamage { get; protected set; }

        /// <summary>
        /// Specifies whether this character is dead or alive.
        /// </summary>
        public bool IsAlive { get; protected set; }

        /// <summary>
        /// Returns the total hit points of this character.
        /// </summary>
        public int TotalHitPoints { get; protected set; }

        /// <summary>
        /// Returns the current hit points of this character.
        /// </summary>
        public int CurrentHitPoints
        {
            get
            {
                return this.currentHitPoints;
            }
            protected set
            {
                this.currentHitPoints = value;

                if (this.currentHitPoints <= 0)
                {
                    this.IsAlive = false;
                    this.currentHitPoints = 0;
                }
            }
        }

        /// <summary>
        /// Gets the SkillCollection associated with this character.
        /// </summary>
        public SkillCollection AvailableSkills
        {
            get
            {
                return this.availableSkills;
            }
            private set
            {
                this.availableSkills = value;
            }
        }

        /// <summary>
        /// Gets all active status effects on this character.
        /// </summary>
        public ICollection<StatusEffect> ActiveEffects
        {
            get
            {
                return new List<StatusEffect>(this.activeEffects);
            }
        }

        /// <summary>
        /// Gets the current status of the character: Active, Stunned or Frightened
        /// </summary>
        public CombatStatus CurrentStatus { get; protected set; }

        protected bool IsPoisoned { get; set; }

        public ICollection<Skill> Buffs
        {
            get
            {
                return new List<Skill>(this.buffs);
            }
        }

        public ICollection<Skill> Debuffs
        {
            get
            {
                return new List<Skill>(this.debuffs);
            }
        }


        /// <summary>
        /// Deals the current character's damage to the selected target.
        /// In this case, the AI controls the attack - whether normal attack or spellcast.
        /// </summary>
        /// <param name="target">The targeted character.</param>
        /// <returns>AttackLog which holds information if the attack passed, as well as the damage dealt and type of attack.</returns>
        public virtual AttackLog DealDamage(IAttackable target)
        {
            if (target.IsAlive)
            {
                SkillDamage attackPower = this.AvailableSkills["basic attack"].DealDamage(this.AttackDamage);
                var result = target.TakeDamage(attackPower);
                result.AttackDetails = String.Format("{0} attacks {1}", this.Name, result.AttackDetails);
                return result;
            }
            else
            {
                return AttackLog.AttackFailed;
            }
        }

        public virtual AttackLog TakeDamage(SkillDamage damage)
        {
            this.CurrentHitPoints -= damage.Damage;

            if (this.CurrentHitPoints <= 0)
            {
                this.IsAlive = false;
            }

            return new AttackLog(true, String.Format("{0} for {1} damage.", this.Name, damage.Damage));
        }

        public void AddStatusEffect(StatusEffect effectToAdd)
        {
            if (effectToAdd.Effect == StatusEffects.Frightened)
            {
                this.CurrentStatus = CombatStatus.Frightened;

                try
                {
                    var previousEffect = this.activeEffects.First(x => x.Effect == StatusEffects.Frightened);
                    this.activeEffects.Remove(previousEffect);
                }
                catch (InvalidOperationException)
                {
                    
                }
            }
            else if (effectToAdd.Effect == StatusEffects.Stunned)
            {
                this.CurrentStatus = CombatStatus.Stunned;

                try
                {
                    var previousEffect = this.activeEffects.First(x => x.Effect == StatusEffects.Stunned);
                    this.activeEffects.Remove(previousEffect);
                }
                catch (InvalidOperationException)
                {
                    
                }
            }
            else if (effectToAdd.Effect == StatusEffects.Poisoned)
            {
                this.IsPoisoned = true;

                try
                {
                    var previousEffect = this.activeEffects.First(x => x.Effect == StatusEffects.Poisoned);
                    this.activeEffects.Remove(previousEffect);
                }
                catch (InvalidOperationException)
                {
                    
                }
            }

            this.activeEffects.Add(effectToAdd);
        }

        public void Update()
        {
            var expiredEffects = this.activeEffects.Where(x => x.TurnsRemaining <= 0).ToList();

            foreach (var effect in expiredEffects)
            {
                this.RemoveEffect(effect);
            }

            foreach (var effect in this.activeEffects)
            {
                if (effect.Effect == StatusEffects.Bleeding)
                {
                    this.HandleBleedEffect();
                }
                else if (effect.Effect == StatusEffects.Poisoned)
                {
                    this.HandlePoisonEffect();
                }

                effect.DecreaseRemainingTurns();
            }
        }

        private void RemoveEffect(StatusEffect effect)
        {
            this.activeEffects.Remove(effect);

            if (effect.Effect == StatusEffects.Frightened && this.CurrentStatus == CombatStatus.Frightened)
            {
                this.CurrentStatus = CombatStatus.Active;
            }
            else if (effect.Effect == StatusEffects.Stunned && this.CurrentStatus == CombatStatus.Stunned)
            {
                this.CurrentStatus = CombatStatus.Active;
            }
            else if (effect.Effect == StatusEffects.Poisoned && this.IsPoisoned)
            {
                this.IsPoisoned = false;
            }
        }

        public bool CanAttack()
        {
            if (this.CurrentStatus == CombatStatus.Frightened || this.CurrentStatus == CombatStatus.Stunned || !this.IsAlive)
            {
                return false;
            }

            return true;
        }

        private void HandleBleedEffect()
        {
            this.CurrentHitPoints -= (int)(this.TotalHitPoints * 0.05);
        }

        private void HandlePoisonEffect()
        {
            this.CurrentHitPoints -= (int)(this.TotalHitPoints * 0.02);
        }

        public void AddBuff(Skill buff)
        {
            throw new NotImplementedException();
        }

        public void AddDebuff(Skill debuf)
        {
            throw new NotImplementedException();
        }
    }
}
