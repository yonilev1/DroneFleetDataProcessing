using System;
using System.Text.RegularExpressions;
using DroneFleetDataProcessing.drone;
namespace DroneFleetDataProcessingSystem.ValidatorClass
{
    class DroneValidator
    {
        private HashSet<string> _validModel = new()
        {
            "Falcon-X",
            "Raven-M",
            "SkyEye-2",
            "CargoBee",
            "Storm-4",
            "Scout-Lite"
        };
        private HashSet<string> _validCategory = new()
        {
            "Recon",
            "Patrol",
            "Mapping",
            "Delivery",
            "Search"
        };
        private HashSet<string> _validBaseLocation = new()
        {
            "North",
            "South",
            "Central",
            "East",
            "West"
        };
        private List<Drone> _validatedDrones;
        public DroneValidator(List<Drone> drones)
        {
            
            _validatedDrones = drones;
        }
        public bool Excecute(Drone drone)
        {
            return true;
        }
        private bool IsValidId(int id)
        {
            if (_validatedDrones.Any(x => x.id == id) || id < 1)
                return false;
            
            return true;
        }
        private bool IsvalidSerialNumber(string SN)
        {
            if (_validatedDrones.Any(x => x.serialNumber == SN) || !Regex.IsMatch(SN, @"^DR-\d{4}$"))
                return false;

            return true;
        }
        private bool IsValidModel(string model)
        {
            if (! _validModel.Contains(model))
                return false;
            return true;
        }
        private bool IsValidCategory(string category)
        {
            if (!_validCategory.Contains(category))
                return false;
            return true;
        }
        private bool isValidBaseLocatoins(string baseLocations)
        {
            if(!_validBaseLocation.Contains(baseLocations))
                return false;
            return true;
        }
        private bool isValidFlithHours(double flithHours)
        {
            if (flithHours < 0 || flithHours > 2500)
                return false;
            return true;
        }
        private bool isValidBaterryHelth(int baterryHlth)
        {
            if (baterryHlth < 0 ||  baterryHlth > 100)
                return false;
            return true;
        }
        private bool isValidMaxRenge(int maxRenge)
        {
            if(maxRenge < 1 ||  maxRenge > 150)
                return false;
            return true;
        }
        private bool isValidMissionsCompleted(int missionsCompleted)
        {

        }
        private bool isValidStatus(string status)
        {

        }
    }
}