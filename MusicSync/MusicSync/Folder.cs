using System;
using System.Collections.Generic;

namespace MusicSync
{
    public class Folder
    {
        private string name;
        private List<Track> trackList;

        public Folder(string name)
        {
            this.Name = name;
            this.TrackList = new List<Track>();
        }

        public Folder(string name, List<Track> trackList)
            :this(name)
        {
            this.trackList.AddRange(trackList);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Folder name cannot be null.");
                }

                this.name = value;
            }
        }

        public List<Track> TrackList
        {
            get
            {
                return new List<Track>(this.trackList);
            }
            private set
            {
                this.trackList = value;
            }
        }

        public int FileCount
        {
            get
            {
                return this.TrackList.Count;
            }
        }

        public void AddTrack(Track trackToAdd)
        {
            this.trackList.Add(trackToAdd);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
