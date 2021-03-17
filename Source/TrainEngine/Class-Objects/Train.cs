using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class Train
    {
        int Id;
        String Name;
        int MaxSpeed;
        bool EndStation;
        int MaxSpeed;
        
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
