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
        private IEnumerable<Drone> OnOperations()
        {
            return _drones.Where(d => d.status != "Operational");
        }
        private int CountValidData()
        {
            return _allDataLen - _drones.Count;
        }
        private IEnumerable<Drone> TopFiveFlingHours()
        {
            return _drones.OrderByDescending(d => d.flightHours).Take(5);
        }
        private IEnumerable<String> GetAllDitictTyps()
        {
            return _drones.Select(d => d.model).Distinct();
        }
        private string GetNumberOfdronsPerbase()
        private string AvergeBetteryByType()
        private string GetModelWithMostConpliteTasks()
        private string GetBasesWithOperationalDronesBatteryAbove80()
        private string GetThreeModelsWithHighestAverageFlightHours()
    }
}