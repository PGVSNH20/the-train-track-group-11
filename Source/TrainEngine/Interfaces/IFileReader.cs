using System.Collections.Generic;

namespace TrainEngine.Interfaces
{
    interface IFileReader
    {
        public List<object> Load(string url);
    }
}
