using System;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = new DateTime();
            ITravelPlan newTravelPlan = new TrainScheduler(new Train()).StartTrainAt(new TimeTableEntry("Öresund", time)).GeneratePlan();
            Console.WriteLine("Train track!");
            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
            Console.WriteLine("Hello World");
        }
    }
}
