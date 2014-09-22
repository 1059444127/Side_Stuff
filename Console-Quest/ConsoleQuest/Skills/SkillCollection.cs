namespace ConsoleQuest.Skills
{
    using System.Collections;
    using System.Collections.Generic;

    public class SkillCollection : IEnumerable<Skill>
    {
        private readonly IList<Skill> _availableSkills;

        public SkillCollection()
        {
            this._availableSkills = new List<Skill>();
        }

        public SkillCollection(IEnumerable<Skill> skillsToAdd)
        {
            this._availableSkills = new List<Skill>();

            foreach (var skill in skillsToAdd)
            {
                this._availableSkills.Add(skill);
            }
        }
        
        public IList<Skill> AvailableSkills
        {
            get
            {
                return new List<Skill>(this._availableSkills);
            }
        }

        public Skill this[string skillName]
        {
            get
            {
                for (int i = 0; i < this.AvailableSkills.Count; i++)
                {
                    if (skillName.ToLower() == this.AvailableSkills[i].Name.ToLower())
                    {
                        return this.AvailableSkills[i];
                    }
                }

                throw new KeyNotFoundException("No such skill");
            }
        }

        public void AddSkill(Skill skillToAdd)
        {
            this._availableSkills.Add(skillToAdd);
        }

        public IEnumerator<Skill> GetEnumerator()
        {
            for (int i = 0; i < this.AvailableSkills.Count; i++)
            {
                yield return this.AvailableSkills[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}