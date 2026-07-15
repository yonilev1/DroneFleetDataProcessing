using DroneFleetDataProcessing.customexceptions;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.Ireader;
using System.IO;
using System.Text.Json;
namespace DroneFleetDataProcessing.reader;

class JsonReader:IReader
{
    public List<Drone> GetData(string path)
    {
        string jsonContent = File.ReadAllText(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<Drone>? rawDrones = JsonSerializer.Deserialize<List<Drone>>(jsonContent, options);

        if (rawDrones == null)
        {
            throw new UnserelazeblleDataException("Deserialization returned null.");
        }

        if (rawDrones.Count == 0)
        {
            throw new NoDroneReportDataException("The file contains an empty array with no records.");
        }

        return rawDrones;
    }
}
