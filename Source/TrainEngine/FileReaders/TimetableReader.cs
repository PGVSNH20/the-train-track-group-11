using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Interfaces;

namespace TrainEngine.FileReaders
{
    public class TimetableReader : IFileReader
    {
        
        public List<object> Load(string url)
        {
            
            string inputData = new StreamReader(
                            File.Open(url, FileMode.Open)
                                            ).ReadToEnd();

            string[] dataArray = inputData.Split("\n");
            var ListOfTime = new List<object>();
            foreach (string entry in dataArray)
            {
                string[] StationData = entry.Split(",");
                ListOfTime.Add(new TimeTableEntry(Convert.ToInt32(entry[0]), Convert.ToInt32(entry[1]), Convert.ToDateTime(entry[2]), Convert.ToDateTime(entry[3])));
            }
            return ListOfTime;
        }
    }
}
