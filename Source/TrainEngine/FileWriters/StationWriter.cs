using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Interfaces;

namespace TrainEngine.FileWriters
{
    public class StationWriter : IFileWriter
    {
        public void Save(string url, List<object> list)
        {
            using (StreamWriter writer = new StreamWriter(url))
            {
                foreach (Station s in list)
                {

                    writer.Write($"{s.Id};{s.Name},{s.Endstation}");

                }

            }
        }
    }
}
