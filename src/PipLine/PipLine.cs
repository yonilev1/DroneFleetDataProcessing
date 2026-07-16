using DroneFleetDataProcessing.customexceptions;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.reader;
using DroneFleetDataProcessing.Report;
using DroneFleetDataProcessing.ValidatorClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DroneFleetDataProcessing.pipeline
{
    class Pipeline
    {
        public string InputFilePath { get; set; }
        public string OutputPath { get; set; }
        public string OutputTxtPath { get; set; }
        public DroneValidator Validator { get; set; }
        public List<Drone> ValidDroneReports { get; set; }

        public Pipeline(string inputFilePath, string outputPath, string outputTxtPath)
        {

            InputFilePath = inputFilePath;
            OutputPath = outputPath;
            OutputTxtPath = outputTxtPath;
            ValidDroneReports = new List<Drone>();
        }

        private void WriteNewFile()
        {
            try
            {   
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(ValidDroneReports, options);

                File.WriteAllText(OutputPath, json);
                Console.WriteLine($"Step 3: Saving clean data... Clean data saved to: {OutputPath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file {OutputPath}: {ex.Message}");
            }
        }

        private void GenerateReport(int numofalldrones, JsonReader reader)
        {
            List<Drone> FilteredDrons = reader.GetData(OutputPath);
            ReportGenerator report = new ReportGenerator(OutputTxtPath, numofalldrones, FilteredDrons);
            report.Execute();
        }

        public void ExecutePipeline()
        {
            Console.WriteLine("Step 1: Reading raw data...Read records from raw file");

            JsonReader reader = new JsonReader();
            List<Drone> rawDrones;

            try
            {
                rawDrones = reader.GetData(InputFilePath);
                Console.WriteLine($"Read {rawDrones.Count} records from raw file");
                Validator = new DroneValidator(rawDrones);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - File '{InputFilePath}' not found.");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - Access denied to the file.");
                return;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - The file contains malformed JSON syntax.");
                return;
            }
            catch (UnserelazeblleDataException ex)
            {
                Console.WriteLine($"Error: NullReferenceException - {ex.Message}");
                return;
            }
            catch (NoDroneReportDataException ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.GetType().Name} - An IO error occurred: {ex.Message}");
                return;
            }

            Console.WriteLine("Step 2: idating data and creating clean dataset... Valid records: Rejected records:");

            foreach (var drone in rawDrones)
            {
                if (Validator.Excecute(drone))
                {
                    ValidDroneReports.Add(drone);
                }
            }

            if (ValidDroneReports.Count == 0)
            {
                throw new AllDataIsInvalidException("all drones are invalid");
            }

            WriteNewFile();
            GenerateReport(rawDrones.Count, reader);
            
        }
    }
}