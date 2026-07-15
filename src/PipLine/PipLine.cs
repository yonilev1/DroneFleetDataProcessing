using System.ComponentModel.DataAnnotations;
using DroneFleetDataProcessingSystem.ValidatorClass;
using DroneFleetDataProcessing.drone;

namespace DroneFleetDataProcessing.pipline;

class Pipline
{
    public string Data { get; set; }
    public string OutputPath { get; set; }
    public DroneValidator Validator { get; set; }
    public List<Drone> ValidDroneReports { get; set; }

    public int RegectedCount { get; set; }
    public Pipline(string data, string outputPath, DroneValidator validator)
    {
        Data = data;
        OutputPath = outputPath;
        Validator = validator;
    }
}