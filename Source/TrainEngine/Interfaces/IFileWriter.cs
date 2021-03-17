using System.Collections.Generic;

namespace TrainEngine.Interfaces
{
    interface IFileWriter
    {
        void Save(string url, List<object> list);
    }
}
