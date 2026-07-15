using DroneFleetDataProcessing.drone;
using System;
using System.Collections.Specialized;
namespace DroneFleetDataProcessing.Report
{
    class ReportGenerator
    {
        private int _allDataLen;
        private string _outPutPath;
        private List<Drone> _drones;
        public ReportGenerator(string outPutPath,int allDataLen, List<Drone> drones)
        {

            _outPutPath = outPutPath;
            _allDataLen = allDataLen;
            _drones = drones;
        }
        public void Execute()
        {
            File.WriteAllText(_outPutPath,"DRONE FLEET ANALYSIS REPORT \n" +
                $"Total raw records: {_allDataLen} \n" +
                $"Valid records: {_drones.Count} \n" +
                $"Rejected records: {RegectedData()} \n" +
                $"\n" +
                $"Operational \n");
            foreach (string drone in OnOperations())
            {
                File.AppendAllText(_outPutPath,$"{drone} \n");
            }
            

            File.AppendAllText(_outPutPath,"TOP 5 DRONES BY FLIGHT HOURS \n");
            foreach (string item in TopFiveFlingHours())
            {
                int count = 1;
                File.AppendAllText(_outPutPath,$"{count}.{item} \n");
                count++;
            }

            File.AppendAllText(_outPutPath,"AVAILABLE DRONE MODELS \n");
            foreach(string type in GetAllDitictTyps())
            {
                File.AppendAllText(_outPutPath,$"{type} \n");
        }
            
            File.AppendAllText(_outPutPath,"DRONES BY BASE \n");
            foreach (string item in GetNumberOfdronsPerbase())
            {
                File.AppendAllText(_outPutPath,$"{item} \n");
            }
            
            File.AppendAllText(_outPutPath, "AVERAGE BATTERY HEALTH BY MODEL");
            foreach (string item in AverageBatteryByType())
            {
                File.AppendAllText(_outPutPath, $"{item} \n");
            }

            Console.WriteLine("Step 5: Performing analysis... Analysis completed successfully");
            Console.WriteLine($"Step 6: Generating report... Report generated successfully: {_outPutPath}");
        }
        private IEnumerable<string> OnOperations()
        {
            return _drones.Where(d => d.status != "Operational").Select(d=>$"{d.serialNumber} | {d.model} | {d.base_location} | {d.status}");
        }

        private IEnumerable<string> TopFiveFlingHours()
        {
            return _drones.OrderByDescending(d => d.flightHours).Take(5).Select(d=>$"{d.serialNumber} | {d.model} | {d.flightHours}");
        }

        private int RegectedData()
        {
            return _allDataLen - _drones.Count;
        }
        
        private IEnumerable<String> GetAllDitictTyps()
        {
            return _drones.Select(d => d.model).Distinct();
        }
        private IEnumerable<String> GetNumberOfdronsPerbase()
        {
            return _drones.GroupBy(d => d.base_location)
                .Select(b => $"{b.Key}: {b.Count()}");
        }
        private IEnumerable<string> AverageBatteryByType()
        {
            return _drones
                .GroupBy(d => d.model)
                .Select(g => $"{g.Key}: {g.Average(d => d.batteryHealth)}%");
        }
        private string GetModelWithMostCompletedTasks()
        {
            return _drones.GroupBy(d => d.model)
                .OrderByDescending(g => g.Sum(d => d.missionsCompleted))
                .Select(g => g.Key).First();                                
                                                       
        }

        private IEnumerable<string> GetBasesWithOperationalDronesBatteryAbove80()
        {
            return _drones
                .Where(d => d.status == "Operational" && d.batteryHealth > 80)
                .Select(d => d.base_location)
                .Distinct();
        }
        private IEnumerable<string> GetThreeModelsWithHighestAverageFlightHours()
        {
            return _drones
                .GroupBy(d => d.model)                                        
                .OrderByDescending(g => g.Average(d => d.flightHours))  
                .Select(g => g.Key)   
                .Take(3);                              
        }
    }
}