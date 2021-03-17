using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Class_Objects
{
    public class TrackSegment
    {
        public string TrackType { get; }
        public TrackSegment(string type)
        {
            TrackType = type;
        }
    }
}
