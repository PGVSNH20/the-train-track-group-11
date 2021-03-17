using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Interfaces;

namespace TrainEngine.FileWriters
{
    public class TrainWriter : IFileWriter
    {
        public void Save(string url, List<object> list)
        {
            // ID,Name,MaxSpeed,Operated
            
            
            using (StreamWriter writer = new StreamWriter(url))
            {
                int counter = 1;

                writer.Write("Id,Name,MaxSpeed,Operated");
                foreach (Train t in list)
                {

                    writer.Write($"{t.Id};{p.Name}");

                }

            }
        }
    }
}
