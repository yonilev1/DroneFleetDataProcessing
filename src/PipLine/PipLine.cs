using System.ComponentModel.DataAnnotations;
using DroneFleetDataProcessingSystem.ValidatorClass;

namespace DroneFleetDataProcessing.pipline;

class Piline
{
    private string _data;
    private string _outputPath;
    private DroneValidator _validator;
}