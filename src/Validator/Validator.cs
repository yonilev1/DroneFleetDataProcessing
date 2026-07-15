using System;
using System.Text.RegularExpressions;
using DroneFleetDataProcessing.SetClass;
using DroneFleetDataProcessing.drone;
namespace DroneFleetDataProcessing.ValidatorClass
{
    class DroneValidator
    {
        SetDrone sd = new SetDrone();
        
        private List<Drone> _validatedDrones;
        public DroneValidator(List<Drone> drones)
        {
            
            _validatedDrones = drones;
        }
        public bool Excecute(Drone drone)
        {
            if(!IsValidId(drone.id))
                return false;
            if(!IsValidSerialNumber(drone.serialNumber))
                return false;
            if(!IsValidModel(drone.model))
                return false;  
            if(!IsValidCategory(drone.category))
                return false;
            if(!IsValidBaseLocatoins(drone.baseLocation))
                return false;
            if(!IsValidFlithHours(drone.flightHours))
                return false;
            if(!IsValidBaterryHelth(drone.batteryHealth))
                return false;
            if(!IsValidMaxRenge(drone.maxRangeKm))
                return false;
            if(!IsValidMissionsCompleted(drone.missionsCompleted))
                return false;
            if(!IsValidStatus(drone.status))
                return false;
            return true;
        }
        private bool IsValidId(int id)
        {
            if (_validatedDrones.Any(x => x.id == id) || id < 1)
                return false;
            
            return true;
        }
        private bool IsValidSerialNumber(string SN)
        {
            if (_validatedDrones.Any(x => x.serialNumber == SN) || !Regex.IsMatch(SN, @"^DR-\d{4}$"))
                return false;

            return true;
        }
        private bool IsValidModel(string model)
        {
            if (!sd.ValidModel.Contains(model))
                return false;
            return true;
        }
        private bool IsValidCategory(string category)
        {
            if (!sd.ValidCategory.Contains(category))
                return false;
            return true;
        }
        private bool IsValidBaseLocatoins(string baseLocations)
        {
            if(!sd.ValidBaseLocation.Contains(baseLocations))
                return false;
            return true;
        }
        private bool IsValidFlithHours(double flithHours)
        {
            if (flithHours < 0 || flithHours > 2500)
                return false;
            return true;
        }
        private bool IsValidBaterryHelth(int baterryHlth)
        {
            if (baterryHlth < 0 ||  baterryHlth > 100)
                return false;
            return true;
        }
        private bool IsValidMaxRenge(double maxRenge)
        {
            if(maxRenge < 1 ||  maxRenge > 150)
                return false;
            return true;
        }
        private bool IsValidMissionsCompleted(int missionsCompleted)
        {
            if (missionsCompleted < 0 ||  missionsCompleted > 5000)
                return false;
            return true;
        }
        private bool IsValidStatus(string status)
        {
            if(!sd.ValidStatus.Contains(status))
                return false;
            return true;
        }
    }
}