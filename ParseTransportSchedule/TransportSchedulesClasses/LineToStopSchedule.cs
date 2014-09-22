using System;
using System.Collections.Generic;

namespace TransportSchedulesClasses
{
    public class LineToStopSchedule
    {
        public LineToStopSchedule(int lineID)
        {
            this.LineID = lineID;
            this.TimeAtStop = new List<DateTime>();
        }

        public int LineID { get; private set; }

        public List<DateTime> TimeAtStop { get; private set; }
    }
}
