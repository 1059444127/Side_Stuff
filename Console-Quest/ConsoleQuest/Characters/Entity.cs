namespace ConsoleQuest.Characters
{
    using System;

    /// <summary>
    /// Abstract Entity class, from which all game characters derrive their names
    /// </summary>
    public abstract class Entity
    {
        private string name;

        public Entity(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets the name of the character
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Character name must be at least 2 symbols.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Returns a brief description of the character.
        /// </summary>
        public string Description { get; protected set; }
    }
}
