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
            /*
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
            PassengerReader passengerReader = new PassengerReader();
            var pr = passengerReader.Load(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\passengers.txt");
            foreach (Passenger p in pr)
            {
                Console.WriteLine(p.Name);
            }

            List<Train> t = new TrainReader(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\trains.txt")
                                            .PrintList();

            List<Station> stationList = new StationReader().Load(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\stations.txt");
            stationList.ForEach(s => Console.WriteLine(s.Name));
            */ 
            List<object> listOfTrackLists = new TraintrackReader().Load(@"C:\plushogskolan\Dataåtkomster i .NET\The Train Track\Source\TrainEngine\Data\traintrack3.txt");

            foreach (List<TrackSegment> tl in listOfTrackLists)
            {
                foreach (TrackSegment track in tl)
                {
                    Console.WriteLine(track.TrackType);
                }
                Console.WriteLine("Next Track");
                Console.ReadLine();
                Console.Clear();
            }


           
        }
    }
}
