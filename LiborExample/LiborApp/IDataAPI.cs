using System.Collections.Generic;
using System.IO;

namespace LiborApp
{
    interface IDataApi
    {
        StreamReader GetStreamReader(string filePath);
        IEnumerable<LiborValues> GetLiborValues(StreamReader reader, List<LiborValues> liborList);
    }
}
