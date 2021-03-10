
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class TimeTableEntry
    {
        public bool ArriveOrDepart { get; set; }
        public string Station { get; }
        public DateTime Time { get; }
        /*public TimeTableEntry(bool arriveOrDepart, string station, DateTime time)
        {
            ArriveOrDepart = arriveOrDepart;
            Station = station;
            Time = time;
        }*/
        public TimeTableEntry(string station, DateTime time)
        {
            Station = station;
            Time = time;
        }
    }
}
