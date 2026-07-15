namespace DroneFleetDataProcessing.drone;

class Drone
{
	public int? id { get; set; }
	public string? serialNumber { get; set; }
	public string? model { get; set; }
	public string? category { get; set; }
	public string? baseLocation { get; set; }
	public double? flightHours { get; set; }
	public int? batteryHealth { get; set; }
	public double? maxRangeKm { get; set; }
	public int? missionsCompleted { get; set; }
	public string? status { get; set; }
}