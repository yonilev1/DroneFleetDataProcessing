using DroneFleetDataProcessing.customexceptions;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.pipeline;
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

        string outputDirectoryPath = Path.Combine(baseDirectory, outputFoldername);
        if (!Directory.Exists(outputDirectoryPath))
        {
            Directory.CreateDirectory(outputDirectoryPath);
        }

        string outputPath = Path.Combine(outputDirectoryPath, outputFileName);

        Pipeline pipline = new Pipeline(inputPath, outputPath);
        try
        {
            pipline.ExecutePipeline();

        }
        catch (AllDataIsInvalidException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}