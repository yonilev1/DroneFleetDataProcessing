using DroneFleetDataProcessing.drone;

namespace DroneFleetDataProcessing.Ireader;

interface IReader
{
	public List<Drone> GetData(string path);
}
