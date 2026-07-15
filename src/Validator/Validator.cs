using System;
using System.Text.RegularExpressions;
using DroneFleetDataProcessing.drone;
namespace DroneFleetDataProcessingSystem.ValidatorClass
{
    class Validator
    {
        private List<Drone> _validatedDrones;
        public Validator(List<Drone> drones)
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

        }
        private bool IsValidCategory(string category)
        {

        }
        private bool isValidBaseLocatoins(string baseLocations)
        {

        }
        private bool isValidFlithHours(double flithHours)
        {

        }
        private bool isValidBaterryHelth(int baterryHlth)
        {

        }
        private bool isValidMaxRenge(int maxRenge)
        {

        }
        private bool isValidMissionsCompleted(int missionsCompleted)
        {

        }
        private bool isValidStatus(string status)
        {

        }
    }
}