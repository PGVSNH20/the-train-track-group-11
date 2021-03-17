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
            
            //PassengerReader pr = new PassengerReader();
            //List<Object> passengers = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Data\passengers.txt");

            StationReader sr = new StationReader();
            List<Object> stations = sr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Data\stations.txt");

            TimetableReader tr = new TimetableReader();
            List<Object> timetable = tr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Data\timetable.txt");

            //TrainReader trr = new TrainReader();
            //List<Object> trains = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            //foreach (Passenger x in passengers) Works
            //{
            //    Console.WriteLine(x.Name);
            //}

            foreach(TimeTableEntry x in timetable)
            {
                Console.WriteLine(x.TrainId) ;
            }







        }
    }
}
