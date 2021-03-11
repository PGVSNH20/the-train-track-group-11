using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine
{
    public class Train
    {
        int Id;
        String Name;
        bool EndStation;
        
        public Train(int id, String name, bool endStation)
        {
            Id = id;
            Name = name;
            EndStation = endStation;
        
        }

        public String PrintTrain()
        {
            return $"Id:{Id} Name: {Name} Endstation: {EndStation}";
        }
    }
}
