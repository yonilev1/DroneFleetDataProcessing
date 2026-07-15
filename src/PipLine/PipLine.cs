using System.ComponentModel.DataAnnotations;
using DroneFleetDataProcessing.ValidatorClass;
using DroneFleetDataProcessing.drone;

namespace DroneFleetDataProcessing.pipline;

class Pipline
{
    public string Data { get; set; }
    public string OutputPath { get; set; }
    public DroneValidator Validator { get; set; }
    public List<Drone> ValidDroneReports { get; set; }
    public int RegectedCount { get; set; }

    public Pipline(string data, string outputPath)
    {
        Data = data;
        OutputPath = outputPath;
        ValidDroneReports = new List<Drone>();
        Validator = new DroneValidator(ValidDroneReports);

    }
}