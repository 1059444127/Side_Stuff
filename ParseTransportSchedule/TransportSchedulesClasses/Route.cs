using System.Collections.Generic;

namespace TransportSchedulesClasses
{
    public class Route
    {
        public Route(int routeID, string name)
        {
            this.RouteID = routeID;
            this.Name = name;

            this.Stops = new List<RouteStop>();
        }

        public int RouteID { get; private set; }

        public string Name { get; private set; }

        public List<RouteStop> Stops { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
