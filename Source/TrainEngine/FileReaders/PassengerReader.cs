using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TrainEngine.Class_Objects;

namespace TrainEngine.FileReaders
{
    public class PassengerReader
    {
        List<Passenger> listOfPassengers { get; }

        public PassengerReader(string url)
        {
            string inputData = new StreamReader(
                            File.Open("C:\\plushogskolan\\Dataåtkomster i .NET\\The Train Track\\Source\\TrainEngine\\Data\\passengers.txt", FileMode.Open)
                                            ).ReadToEnd();

            string[] dataArray = inputData.Split("\n");
            listOfPassengers = new List<Passenger>();
            foreach(string passenger in dataArray)
            {
                string[] passengerData = passenger.Split(";");
                listOfPassengers.Add(new Passenger(Convert.ToInt32(passengerData[0]), passengerData[1]));
            }
        }

        public List<Passenger> GetPassengers()
        {
            return listOfPassengers;
        }
    }
}
