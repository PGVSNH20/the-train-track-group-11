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
            List<Object> passengers = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            StationReader sr = new StationReader();
            List<Object> stations = sr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            TimetableReader tr = new TimetableReader();
            List<Object> timetable = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            TrainReader trr = new TrainReader();
            List<Object> trains = pr.Load(@"C:\Users\Robert\Source\Repos\the-train-track-group-11\Source\TrainEngine\FileReaders\PassengerReader.cs");

            foreach (Passenger x in passengers)
            {
                Console.WriteLine(x.Name);
            }



           

           
        }
    }
}
