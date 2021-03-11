using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Class_Objects
{
    public class Passenger
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Passenger(int id, string name)
        {
            Name = name;
            ID = id;
        }
    }
}
