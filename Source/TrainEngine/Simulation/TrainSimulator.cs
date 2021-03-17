using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TrainEngine.Class_Objects;
using TrainEngine.FileReaders;

namespace TrainEngine.Simulation
{
    /*
     *  Quick explanation:
     *  The train will travel at a rate of 1000 units per second.
     *  Each type of track will have a value (based on what type of track it is) that decides how long it will take for a train to pass it.
     *  This means that if a type of track takes 500 units to pass, it'll take half a second to pass.
     *  A track that takes 1200 units will take 1.2 seconds to pass.
     *  You get the idea.
     *
     */
    public class TrainSimulator
    {
        Train myTrain;
        List<TrackSegment> myTrack;
        Dictionary<string, int> TrackTimeUnits = new Dictionary<string, int>();

        public TrainSimulator()
        {
            TrackTimeUnits.Add("StartingPosition", 0);
            TrackTimeUnits.Add("StationStart", 100);
            TrackTimeUnits.Add("StationEnd", 100);
            TrackTimeUnits.Add("HorizontalTrack", 1000);
            TrackTimeUnits.Add("DiagonalUpRightTrack", 1400);
            TrackTimeUnits.Add("DiagonalDownRightTrack", 1400);
            TrackTimeUnits.Add("LevelCrossingTrack", 2000);
            TrackTimeUnits.Add("BranchSplit", 1500);
            TrackTimeUnits.Add("BrachJoin", 1500);
            TrackTimeUnits.Add("Station 1", 5000);
            TrackTimeUnits.Add("Station 2", 5000);
            TrackTimeUnits.Add("Station 3", 5000);
            TrackTimeUnits.Add("Station 4", 5000);
            myTrack = new List<TrackSegment>();
        }
        public TrainSimulator GetTrain()
        {
            var reader = new TrainReader();
            myTrain = (Train)reader.Load(@$"{Directory.GetCurrentDirectory()}\Data\trains.txt")[new Random().Next(4)];
            return this;
        }
        public TrainSimulator GetTrack()
        {
            var reader = new TraintrackReader2();
            List<object> trackSegments = reader.Load(@$"{Directory.GetCurrentDirectory()}\Data\traintrack2.txt");
            foreach (TrackSegment s in trackSegments)
            {
                myTrack.Add(s);
            }
            return this;
        }
        public TrainSimulator RunSimulation()
        {
            foreach (TrackSegment t in myTrack)
            {
                if(t.TrackType != "StartingPosition")
                {
                    Console.WriteLine($"{myTrain.Name} passing by {t.TrackType}");
                    Thread.Sleep(TrackTimeUnits[t.TrackType]);
                }
            }
            Console.WriteLine($"{myTrain.Name} has completed its journey. Have a nice.");
            return this;
        }

    }
}
