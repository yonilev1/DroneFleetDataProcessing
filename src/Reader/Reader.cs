using DroneFleetDataProcessing.Ireader;
using System.IO;
namespace DroneFleetDataProcessing.reader;

class JsonReader:IReader
{
    public string GetData(string path)
    {
        return File.ReadAllText(path);
    }
}
