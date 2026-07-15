using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DroneFleetDataProcessing.drone;
using DroneFleetDataProcessing.ValidatorClass;
using DroneFleetDataProcessing.customexceptions;

namespace DroneFleetDataProcessing.pipeline
{
    class Pipeline
    {
        public string InputPath { get; set; }
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


        private void serelize() 
        {
        
        }
        private void Validate()
        {
        
            foreach (Drone drone in )
            {
                try
                {
                    if (!Validator.Excecute(drone))
                    {
                        RejectedCount++;
                        throw new UnserelazeblleDataException("data not serelisable");
                                        
                    }
                }
                catch (UnserelazeblleDataException ex)
                {

                }

              
                
            }
            
            if (ValidDroneReports.Count == 0)
            {
                throw new AllDataIsInvalidException("report file is full of invalid data");
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