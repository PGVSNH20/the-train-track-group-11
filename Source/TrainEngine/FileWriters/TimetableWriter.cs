using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Interfaces;

namespace TrainEngine.FileWriters
{
    public class TimetableWriter : IFileWriter
    {
        public void Save(string url, List<object> list)
        {
            using (StreamWriter writer = new StreamWriter(url))
            {
                foreach (TimeTableEntry t in list)
                {

                    writer.Write($"{t.TrainId};{t.StationId},{t.Arrival},{t.Arrival}");

                }

            }
        }
    }
}
