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







        }

           
        }
    }
}
