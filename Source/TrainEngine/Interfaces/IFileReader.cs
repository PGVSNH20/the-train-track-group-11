using System.Collections.Generic;

namespace TrainEngine.Interfaces
{
    interface IFileReader
    {
        List<object> Load(string url);
    }
}
