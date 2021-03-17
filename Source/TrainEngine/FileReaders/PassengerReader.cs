    using System;
using System.Collections.Generic;
using System.IO;
using TrainEngine.Class_Objects;
using TrainEngine.Interfaces;

namespace TrainEngine.FileReaders
{
    public class PassengerReader : IFileReader
    {
        List<object> listOfPassengers { get; set; }

        public List<object> Load(string url)
        {
            string inputData = new StreamReader(
                            File.Open(url, FileMode.Open)
                                            ).ReadToEnd();

            string[] dataArray = inputData.Split("\n");
            listOfPassengers = new List<object>();
            foreach(string passenger in dataArray)
            {
                string[] passengerData = passenger.Split(";");
                listOfPassengers.Add(new Passenger(Convert.ToInt32(passengerData[0]), passengerData[1]));
            }
            return listOfPassengers;
        }
    }
}
