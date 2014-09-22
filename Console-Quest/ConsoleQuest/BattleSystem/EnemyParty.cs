namespace ConsoleQuest.BattleSystem
{
    using ConsoleQuest.Characters;
    using ConsoleQuest.Common;
    using System;
    using System.Collections.Generic;

    public class EnemyParty<T> where T: Enemy
    {
        private const int MaximumCapacity = 3;

        /// <summary>
        /// Dynamic enemy party genereration.
        /// Based ot number of player-party memebers,
        /// and their average level.
        /// </summary>
        /// <param name="playerPartyCount">Specifies the size of the party.</param>
        /// <param name="playerPartyLevel">Specifies the level for the enemies.</param>
        /// <param name="enemyType">Specifies the enemy type.</param>
        /// <returns>A new enemy party consisting of the given type.</returns>
        public static EnemyParty<T> GenerateParty(int playerPartyCount, int playerPartyLevel)
        {
            /* This method uses reflection to dynamically create the specified enemies.
             * First, it specifies the type of the enemy created,
             * and then it specifies the constructor parameters.
             * Even though the desired type is casted down to Enemy, 
             * this dynamic object creation is needed to properly populate the desired enemy skillbook */
            Type type = typeof(T);
            Object[] arguments = { playerPartyLevel };

            EnemyParty<T> result = new EnemyParty<T>();
            for (int i = 0; i < playerPartyCount; i++)
            {
                object instance = Activator.CreateInstance(type, arguments);
                result.AddMember((instance as T));
            }

            return result;
        }

        private readonly IList<T> _partyMembers;

        public EnemyParty()
        {
            this._partyMembers = new List<T>();
        }

        public EnemyParty(List<T> partyToAdd)
        {
            this._partyMembers = new List<T>();

            foreach (var member in partyToAdd)
            {
                this.AddMember(member);
            }
        }

        public bool IsAlive
        {
            get
            {
                foreach (T member in this.PartyMembers)
                {
                    if (member.IsAlive)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public IList<T> PartyMembers
        {
            get
            {
                return new List<T>(this._partyMembers);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.PartyMembers.Count)
                {
                    throw new IndexOutOfRangeException("The specified index was out of the bounds of the party.");
                }

                return this.PartyMembers[index];
            }
        }

        public void AddMember(T member)
        {
            if (this.PartyMembers.Count >= MaximumCapacity)
            {
                throw new InvalidOperationException("You have reached the maximum party capacity.");
            }

            foreach (T enemy in this.PartyMembers)
            {
                while (member.Name == enemy.Name)
                {
                    member.Name = RandomGenerator.GetRandomName(typeof(T).Name);
                }
            }

            this._partyMembers.Add(member);
        }
    }
}
