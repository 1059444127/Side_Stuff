using System;

namespace TransportSchedulesClasses
{
    public struct StopLocation
    {
        public StopLocation(string lat, string lon)
            :this()
        {
            this.Lat = lat;
            this.Lon = lon;
        }

        public string Lat { get; set; }
        public string Lon { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Lat, this.Lon);
        }
    }
}
