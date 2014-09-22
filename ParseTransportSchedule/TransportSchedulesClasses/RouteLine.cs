using System.Collections.Generic;

namespace TransportSchedulesClasses
{
    public class RouteLine : IEnumerable<RouteLine>
    {
        public RouteLine(int lineID)
        {
            this.LineID = lineID;
            this.LineRoute = new List<Route>();
        }

        public RouteLine(int lineID, string name, int vehicleTypeID)
            : this(lineID)
        {
            this.Name = name;
            this.VehicleType = vehicleTypeID;
            this.LineRoute = new List<Route>();
        }

        public int LineID { get; private set; }

        public string Name { get; private set; }

        public int VehicleType { get; set; }

        public List<Route> LineRoute { get; set; }

        public IEnumerator<RouteLine> GetEnumerator()
        {
            foreach (var route in this.LineRoute)
            {
                RouteLine currentLine = new RouteLine(this.LineID, this.Name, this.VehicleType);
                currentLine.LineRoute.Add(route);
                yield return currentLine;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return this.LineID == (obj as RouteLine).LineID;
        }
    }
}
