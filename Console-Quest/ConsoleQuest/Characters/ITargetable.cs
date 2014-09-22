using ConsoleQuest.Skills;
using System.Collections.Generic;

namespace ConsoleQuest.Characters
{
    public interface ITargetable
    {
        ICollection<Skill> Buffs { get; }

        ICollection<Skill> Debuffs { get; }

        void AddBuff(Skill buff);

        void AddDebuff(Skill debuf);
    }
        
}
