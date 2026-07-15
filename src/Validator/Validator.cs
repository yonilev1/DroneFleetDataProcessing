using System;
using System.Text.RegularExpressions;
using DroneFleetDataProcessing.SetClass;
using DroneFleetDataProcessing.drone;
namespace DroneFleetDataProcessing.ValidatorClass
{
    class DroneValidator
    {
        SetDrone sd = new SetDrone();
        
        private List<Drone> _allDrones;
        public DroneValidator(List<Drone> drones)
        {

            _allDrones = drones;
        }
        public bool Excecute(Drone drone)
        {
            return IsValidId(drone)
                && IsValidSerialNumber(drone)
                && IsValidModel(drone.model)
                && IsValidCategory(drone.category)
                && IsValidBaseLocatoins(drone.base_location)
                && IsValidFlithHours(drone.flightHours)
                && IsValidBaterryHelth(drone.batteryHealth, drone.status)
                && IsValidMaxRenge(drone.maxRangeKm)
                && IsValidMissionsCompleted(drone.missionsCompleted)
                && IsValidStatus(drone.status);
        }
        private bool IsValidId(Drone currentDrone)
        {
            if (currentDrone.id < 1)
                return false;

            if (_allDrones.Any(x => x.id == currentDrone.id && !ReferenceEquals(x, currentDrone)))
                return false;

            return true;
        }

        private bool IsValidSerialNumber(Drone currentDrone)
        {
            if (!Regex.IsMatch(currentDrone.serialNumber, @"^DR-\d{4}$"))
                return false;

            if (_allDrones.Any(x => x.serialNumber == currentDrone.serialNumber && !ReferenceEquals(x, currentDrone)))
                return false;

            return true;
        }
        private bool IsValidModel(string? model)
        {
            if (!sd.ValidModel.Contains(model))
                return false;
            return true;
        }
        private bool IsValidCategory(string? category)
        {
            if (!sd.ValidCategory.Contains(category))
                return false;
            return true;
        }
        private bool IsValidBaseLocatoins(string? baseLocations)
        {
            if(!sd.ValidBaseLocation.Contains(baseLocations))
                return false;
            return true;
        }
        private bool IsValidFlithHours(double? flithHours)
        {
            if (flithHours < 0 || flithHours > 2500)
                return false;
            return true;
        }
        private bool IsValidBaterryHelth(int? baterryHlth, string? status)
        {
            if (baterryHlth < 0 ||  baterryHlth > 100)
                return false;
            if (baterryHlth < 20 && status == "Operational")
                return false;
            return true;
        }
        private bool IsValidMaxRenge(double? maxRenge)
        {
            if(maxRenge < 1 ||  maxRenge > 150)
                return false;
            return true;
        }
        private bool IsValidMissionsCompleted(int? missionsCompleted)
        {
            if (missionsCompleted < 0 ||  missionsCompleted > 5000)
                return false;
            return true;
        }
        private bool IsValidStatus(string? status)
        {
            if(!sd.ValidStatus.Contains(status))
                return false;
            return true;
        }
    }
}