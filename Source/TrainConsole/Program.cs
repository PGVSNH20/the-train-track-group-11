using System;
using System.Collections.Generic;
using System.IO;
using TrainEngine;
using TrainEngine.Class_Objects;
using TrainEngine.FileReaders;
using TrainEngine.FileWriters;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //PassengerReader pr = new PassengerReader();
            //List<Object> passengers = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Data\passengers.txt");

            StationReader sr = new StationReader();
            List<Object> stations = sr.Load(@$"{Directory.GetCurrentDirectory()}\Data\stations.txt");

            TimetableReader tr = new TimetableReader();
            List<Object> timetable = tr.Load(@$"{Directory.GetCurrentDirectory()}\Data\timetable.txt");

            //TrainReader trr = new TrainReader();
            //List<Object> trains = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            //foreach (Passenger x in passengers) Works
            //{
            //    Console.WriteLine(x.Name);
            //}

            foreach(TimeTableEntry x in timetable)
            {
                Console.WriteLine(x.TrainId);
                Console.WriteLine(x.StationId);
                Console.WriteLine(x.Arrival);
                Console.WriteLine(x.Departure);
                Console.WriteLine();
            }

            List<object> stationList = new StationReader().Load(@$"{Directory.GetCurrentDirectory()}\Data\stations.txt");
            stationList.ForEach(s => Console.WriteLine(Station.StationFromObject(s).Name));
            List<object> listOfTrackSegments = new TraintrackReader2().Load(@$"{Directory.GetCurrentDirectory()}\Data\traintrack2.txt");
            TraintrackWriter ttW = new TraintrackWriter();
            ttW.Save(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\traintrack2-2.txt", listOfTrackSegments);

            foreach (TrackSegment track in listOfTrackSegments)
            {
                Console.WriteLine(track.TrackType);
            }
        }
    }
}
