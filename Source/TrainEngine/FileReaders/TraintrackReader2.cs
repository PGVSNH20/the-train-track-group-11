using System;
using System.Collections.Generic;
using System.IO;
using TrainEngine.Class_Objects;
using TrainEngine.Interfaces;

namespace TrainEngine.FileReaders
{
    public class TraintrackReader2 : IFileReader
    {
        List<object> trackList = new List<object>();

        public List<object> Load(string url)
        {
            string inputData = File.ReadAllText(url);
            foreach (char c in inputData)
            {
                try
                {
                    trackList.Add(new TrackSegment(TrackInterpreter(c)));
                }
                catch (Exception ex)
                {
                    // Console.WriteLine(ex.Message);
                }
            }

            return (List<object>)trackList;
        }

        private string TrackInterpreter(char c)
        {
            switch (c)
            {
                case '*': return "StartingPosition";
                case '[': return "StationStart";
                case ']': return "StationEnd";
                case '-': return "HorizontalTrack";
                case '/': return "DiagonalUpRightTrack";
                case '\\': return "DiagonalDownRightTrack";
                case '=': return "LevelCrossingTrack";
                case '<': return "BranchSplit";
                case '>': return "BrachJoin";
                case '1': return "Station 1";
                case '2': return "Station 2";
                case '3': return "Station 3";
                case '4': return "Station 4";
                default: throw new Exception("invalid symbol");
            }
        }
    }
}
