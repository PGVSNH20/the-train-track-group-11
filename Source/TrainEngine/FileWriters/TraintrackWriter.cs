using System;
using System.Collections.Generic;
using System.Text;
using TrainEngine.Interfaces;
using System.IO;
using TrainEngine.Class_Objects;

namespace TrainEngine.FileWriters
{
    public class TraintrackWriter : IFileWriter
    {

        public void Save(string url, List<object> list)
        {
            Stream stream = File.Create(url);
            StreamWriter writer = new StreamWriter(stream);
            foreach (TrackSegment t in list)
            {
                writer.Write(TrackInterpreter(t.TrackType));
            }
            writer.Close();
            stream.Close();
        }

        private char TrackInterpreter(string c)
        {
            switch (c)
            {
                case "StartingPosition": return '*';
                case "StationStart": return '[';
                case "StationEnd": return ']';
                case "HorizontalTrack": return '-';
                case "DiagonalUpRightTrack": return '/';
                case "DiagonalDownRightTrack": return '\\';
                case "LevelCrossingTrack": return '=';
                case "BranchSplit": return '<';
                case "BrachJoin": return '>';
                case "Station 1": return '1';
                case "Station 2": return '2';
                case "Station 3": return '3';
                case "Station 4": return '4';
                default: throw new Exception("invalid String");
            }
        }
    }
}
