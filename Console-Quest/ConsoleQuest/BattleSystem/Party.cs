namespace ConsoleQuest.BattleSystem
{
    using ConsoleQuest.Characters;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Party : IEnumerable<Combatant>
    {
        private const int MaximumPartySize = 3;

        private readonly IList<Combatant> _partyMembers;

        public Party()
            :this(null, null, null)
        {

        }

        public Party(Combatant firstCombatant)
            :this(firstCombatant, null, null)
        {
            
        }

        public Party(Combatant firstCombatant, Combatant secondCombatant)
            :this(firstCombatant, secondCombatant, null)
        {
            
        }

        public Party(Combatant firstCombatant, Combatant secondCombatant, Combatant thirdCombatant)
        {
            this._partyMembers = new List<Combatant>();
            if (firstCombatant != null)
            {
                _partyMembers.Add(firstCombatant);
            }

            if (secondCombatant != null)
            {
                _partyMembers.Add(secondCombatant);
            }

            if (thirdCombatant != null)
            {
                _partyMembers.Add(thirdCombatant);
            }
        }

        public IList<Combatant> PartyMembers
        {
            get
            {
                return new List<Combatant>(this._partyMembers);
            }
        }

        public Combatant this[int index]
        {
            get
            {
                if (index < 0 || index >= this.PartyMembers.Count)
                {
                    throw new IndexOutOfRangeException("The specified index was outside the bounds of the collection.");
                }

                return this.PartyMembers[index];
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.PartyMembers.Any(x => x.IsAlive);
            }
        }

        public void UpdateParty()
        {
            foreach (var member in this._partyMembers)
            {
                member.Update();
            }
        }

        public void AddToParty(Combatant entry)
        {
            if (this.PartyMembers.Count >= MaximumPartySize)
            {
                throw new InvalidOperationException("You have reached the maximum party limit!");
            }

            this._partyMembers.Add(entry);
        }

        public IEnumerator<Combatant> GetEnumerator()
        {
            for (int i = 0; i < this.PartyMembers.Count; i++)
            {
                yield return this.PartyMembers[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
