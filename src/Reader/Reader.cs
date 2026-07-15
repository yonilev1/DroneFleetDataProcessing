using Ireader.ireader;
using System.IO;
namespace Reader.reader;

class Reader:IReader
{
    public string GetData(string path)
    {
        return File.ReadAllText(path);
    }
}
