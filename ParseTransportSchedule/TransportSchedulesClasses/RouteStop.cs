using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportSchedulesClasses
{
    public class RouteStop : IEquatable<RouteStop>, ICloneable
    {
        public RouteStop()
        {
            this.StopLocations = new List<StopLocation>();
            this.LineToStopSchedule = new List<LineToStopSchedule>();
        }

        public RouteStop(int publicID)
            : this()
        {
            this.PublicID = publicID;
        }

        public RouteStop(int publicID, string name)
            : this(publicID)
        {
            this.Name = name;
        }

        public int PublicID { get; set; }
        public string Name { get; set; }

        public int Code { get; set; }

        public List<StopLocation> StopLocations { get; private set; }

        public StopLocation DefaultLocation { get; set; }

        public List<LineToStopSchedule> LineToStopSchedule { get; private set; }

        public LineToStopSchedule this[int lineID]
        {
            get
            {
                foreach (var item in this.LineToStopSchedule)
                {
                    if (item.LineID == lineID)
                    {
                        return item;
                    }
                }

                throw new KeyNotFoundException("No such schedule found.");
            }
        }

        public LineToStopSchedule GetScheduleByID(int lineID)
        {
            return this.LineToStopSchedule.Where(x => x.LineID == lineID).First();
        }

        public bool Equals(RouteStop other)
        {
            return this.PublicID == other.PublicID;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public object Clone()
        {
            RouteStop result = new RouteStop(this.PublicID, this.Name);
            result.Code = this.Code;
            result.DefaultLocation = this.DefaultLocation;
            for (int i = 0; i < this.StopLocations.Count; i++)
            {
                result.StopLocations.Add(this.StopLocations[i]);
            }

            return (result as RouteStop);
        }
    }
}
