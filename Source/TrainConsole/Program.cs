using System;
using System.Collections.Generic;
using TrainEngine;
using TrainEngine.Class_Objects;
using TrainEngine.FileReaders;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PassengerReader pr = new PassengerReader();
            List<Object> passengers = pr.Load("gg");

            StationReader sr = new StationReader();
            List<Object> stations = sr.Load("gg");



            List<object> stationList = new StationReader().Load(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\stations.txt");
            stationList.ForEach(s => Console.WriteLine(Station.StationFromObject(s).Name));
            List<object> listOfTrackSegments = new TraintrackReader2().Load(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\traintrack2.txt");

            foreach (TrackSegment track in listOfTrackSegments)
            {
                Console.WriteLine(track.TrackType);
            }
        }
    }
}
