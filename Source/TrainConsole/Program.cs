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
            ITravelPlan newTravelPlan = new TrainScheduler(new Train(1, "Jiminy", true))
                                                .StartTrainAt(new TimeTableEntry("Öresund", time))
                                                .GeneratePlan();
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
            PassengerReader passengerReader = new PassengerReader();
            var pr = passengerReader.Load("C:\\plushogskolan\\Dataåtkomster i .NET\\The Train Track\\Source\\TrainEngine\\Data\\passengers.txt");
            foreach (Passenger p in pr)
            {
                Console.WriteLine(p.Name);
            }

            List<Train> t = new TrainReader("").TrainList;

            foreach(Train x in t)
            {
                x.PrintTrain();
            }
        }
    }
}
