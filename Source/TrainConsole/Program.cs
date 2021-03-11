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
            DateTime time = new DateTime();
            ITravelPlan newTravelPlan = new TrainScheduler(new Train())
                                                .StartTrainAt(new TimeTableEntry("Öresund", time))
                                                .GeneratePlan();
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
            List<Passenger> pr = new PassengerReader("").GetPassengers();
            foreach (Passenger p in pr)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
