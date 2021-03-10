using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    class TravelPlan : ITravelPlan
    {
        public List<TimeTableEntry> TimeTable { get; }

        public Train Train { get; }
        public TravelPlan(List<TimeTableEntry> list, Train newTrain)
        {
            Train = newTrain;
            TimeTable = list;
        }

        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }
    }
}
