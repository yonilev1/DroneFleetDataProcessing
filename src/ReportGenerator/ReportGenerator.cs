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

        }
        private IEnumerable<string> OnOperations()
        {
            return _drones.Where(d => d.status != "Operational").Select(d=>$"{d.serialNumber} | {d.model} | {d.base_location} | {d.status}");
        }

        private IEnumerable<string> TopFiveFlingHours()
        {
            return _drones.OrderByDescending(d => d.flightHours).Take(5).Select(d=>$"{d.serialNumber} | {d.model} | {d.flightHours}");
        }

        private int CountValidData()
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
        
    }
}