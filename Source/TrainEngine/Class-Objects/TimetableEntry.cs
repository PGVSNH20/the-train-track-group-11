
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class TimeTableEntry
    {

        public int TrainId { get; set; }
        public int StationId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

        public TimeTableEntry(int id, int sid, DateTime arrival, DateTime departure)
        {
            TrainId = id;
            StationId = sid;
            Arrival = arrival;
            Departure = departure;
        }

    }
}
