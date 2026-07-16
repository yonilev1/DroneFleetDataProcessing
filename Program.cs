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
        Console.WriteLine(" === Drone Fleet Data Processing System ===");
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = "input";
        string innerFolderName = "raw";
        string fileName = "drones_raw.json";
        string inputPath = Path.Combine(baseDirectory, folderName, innerFolderName, fileName);

        string outputFoldername = "output";
        string outputFileName = "drones_clean.json";
        string outputTxtFile = "analysis_report.txt";

        string outputDirectoryPath = Path.Combine(baseDirectory, outputFoldername);
        if (!Directory.Exists(outputDirectoryPath))
        {
            Directory.CreateDirectory(outputDirectoryPath);
        }

        string outputPath = Path.Combine(outputDirectoryPath, outputFileName);
        string outputTxtFullPath = Path.Combine(outputDirectoryPath, outputTxtFile);

        Pipeline pipline = new Pipeline(inputPath, outputPath, outputTxtFullPath);
        try
        {
            pipline.ExecutePipeline();

        }
        catch (AllDataIsInvalidException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("=== Process completed successfully! ===");
    }
}