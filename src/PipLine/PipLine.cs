using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.ValidatorClass;

namespace DroneFleetDataProcessing.pipeline
{
    class Pipeline
    {
        public string Data { get; set; }
        public string OutputPath { get; set; }
        public DroneValidator Validator { get; set; }
        public List<Drone> ValidDroneReports { get; set; }
        public int RejectedCount { get; set; }

        public Pipeline(string data, string outputPath)
        {

            Data = data;
            OutputPath = outputPath;
            ValidDroneReports = new List<Drone>();
            Validator = new DroneValidator(ValidDroneReports);
        }

        private void Parse()
        {
            try
            {

                List<Drone> parsedReports = JsonSerializer.Deserialize<List<Drone>>(Data) ?? new();

                if (parsedReports.Count == 0)
                    

                foreach (Drone drone in parsedReports)
                {

                    
                    if (!Validator.Excecute(drone))
                    {
                        RejectedCount++;
                    }
                }
            }
            catch (JsonException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void WriteNewFile()
        {
            try
            {
                
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(ValidDroneReports, options);

                File.WriteAllText(OutputPath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file {OutputPath}: {ex.Message}");
            }
        }

        public void Execute()
        {
            Parse();
            WriteNewFile();
        }
    }
}