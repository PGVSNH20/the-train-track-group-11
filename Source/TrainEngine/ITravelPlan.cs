using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public interface ITravelPlan
    {
        List<TimeTableEntry> TimeTable { get; }

        Train Train { get; }

        void Save(string path);
        void Load(string path);

    }
}
