
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class TimeTableEntry
    {

        int TrainId { get; set; }
        int StationId { get; set; }
        DateTime Arrival { get; set; }
        DateTime Departure { get; set; }

        public TimeTableEntry(int id, int sid, DateTime arrival, DateTime departure)
        {
            TrainId = id;
            StationId = sid;
            Arrival = arrival;
            Departure = departure;
        }
    }
}
