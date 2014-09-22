using System;

namespace MusicSync
{
    public class Track
    {
        private string name;
        private string path;

        public Track(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Track name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Track path cannot be null or empty.");
                }

                this.path = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Track trackToCheck = obj as Track;

            if (trackToCheck == null)
            {
                return false;
            }

            return this.Name == trackToCheck.Name;
        }

        public bool Equals(Track trackToCheck)
        {
            if (trackToCheck == null)
            {
                return false;
            }

            return this.Name.ToLower() == trackToCheck.Name.ToLower();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}