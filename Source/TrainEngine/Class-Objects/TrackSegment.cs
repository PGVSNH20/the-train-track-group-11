using System;
using System.Collections.Generic;
using System.Text;

namespace TrainEngine.Class_Objects
{
    class TrackSegment
    {
        string TrackType { get; set; }
        public TrackSegment(string type)
        {
            TrackType = type;
        }
    }
}
