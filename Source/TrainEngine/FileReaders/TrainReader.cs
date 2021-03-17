﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TrainEngine.FileReaders
{
    public class TrainReader
    {
        public List<Train> TrainList = new List<Train>();


        public TrainReader(String url)
        {

            String TrainInput = System.IO.File.ReadAllText(url);

            String[] TrainRows = TrainInput.Split(Environment.NewLine);
            for (int x = 1; x < TrainRows.Length; x++)
            {
                String[] col = TrainRows[x].Split(",");
                TrainList.Add(new Train(Int32.Parse(col[0]), col[1], (col[2].ToLower() == "true") ? true : false));
                //TrainList.Add(new Train(Int32.Parse(col[0]), col[1], Convert.ToBoolean(col[2]));

            }

        }

        public List<Train> PrintList()
        {
            foreach(var x in TrainList)
            {
                Console.WriteLine(x.PrintTrain());
            }
            return TrainList;
        }



    }
}
