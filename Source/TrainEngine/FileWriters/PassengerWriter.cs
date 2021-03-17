using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Class_Objects;
using TrainEngine.Interfaces;

namespace TrainEngine.FileWriters
{
    public class PassengerWriter : IFileWriter
    {
        public void Save(string url, List<object> list)
        {

            using (StreamWriter writer = new StreamWriter(url))
            {
                foreach (Passenger p in list)
                {

                    writer.Write($"{p.ID};{p.Name}");

                }
               
            }

            







            
        }
    }
}
