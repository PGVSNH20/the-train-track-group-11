using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class Station
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool Endstation { set; get; }


        public Station(int id, string name, bool endstation)
        {
            Id = id;
            Name = name;
            Endstation = Endstation;
        }


    }
}
