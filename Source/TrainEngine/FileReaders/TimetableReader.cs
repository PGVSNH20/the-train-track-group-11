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

            for (int i = 1; i < dataArray.Length; i++)
            {
                
                string[] StationData = dataArray[i].Split(",");
                ListOfTime.Add(new TimeTableEntry(Convert.ToInt32(StationData[0]), Convert.ToInt32(StationData[1]), Convert.ToDateTime(StationData[2]), Convert.ToDateTime(StationData[3])));
            }
            
            
            return ListOfTime;
        }
    }
}
