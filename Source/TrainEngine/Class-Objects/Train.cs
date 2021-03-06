using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class Train
    {
        int Id;
        public string Name { get; }
        int MaxSpeed;
        bool EndStation;
        
        public Train(int id, String name, int max, bool endStation)
        {
            Id = id;
            Name = name;
            MaxSpeed = max;
            EndStation = endStation;
        
        }

        public String PrintTrain()
        {
            return $"Id:{Id} Name: {Name} Endstation: {EndStation}";
        }
    }
}
