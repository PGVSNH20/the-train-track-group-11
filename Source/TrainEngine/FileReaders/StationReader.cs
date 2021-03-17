using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.FileReaders
{
    public class StationReader
    {
        List<Station> StationList = new List<Station>();
        
        public List<Station> Load(string url)
        {
            
            String input = System.IO.File.ReadAllText(url);

            String[] rows = input.Split(Environment.NewLine);
            for (int x = 1; x < rows.Length; x++)
            {
                String[] col = rows[x].Split("|");
                
            
                StationList.Add(new Station(Int32.Parse(col[0]),col[1], (col[2].ToLower() == "true") ? true : false));
                //TrainList.Add(new Train(Int32.Parse(col[0]), col[1], Convert.ToBoolean(col[2]));

            }


            


            return StationList;
        }

           
    }
}
