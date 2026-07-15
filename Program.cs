using DroneFleetDataProcessing.customexceptions;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.pipline;
using DroneFleetDataProcessing.reader;
using DroneFleetDataProcessing.ValidatorClass;
using System.IO;

class Program
{
    static void Main()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "input";
        string innerFolderName = "raw";
        string fileName = "drones_raw.json";
        string inputPath = Path.Combine(baseDirectory, folderName, innerFolderName, fileName);

        string outputFoldername = "output";
        string outputFileName = "drones_clean.json";
        string outputPath = Path.Combine(baseDirectory, outputFoldername, outputFileName);

        Pipline pipline = new Pipline(inputPath, outputPath);
    }
}