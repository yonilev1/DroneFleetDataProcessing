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
        private bool isValidBaseLocatoins(string baseLocations)
        {
            if(!sd.ValidBaseLocation.Contains(baseLocations))
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
            if (missionsCompleted < 0 ||  missionsCompleted > 5000)
                return false;
            return true;
        }
        private bool isValidStatus(string status)
        {
            if(!sd.ValidStatus.Contains(status))
                return false;
            return true;
        }
    }
}