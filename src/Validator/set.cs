using System;
namespace DroneFleetDataProcessing.SetClass
{
   class SetDrone
    {
        public HashSet<string> ValidModel = new()
        {
            "Falcon-X",
            "Raven-M",
            "SkyEye-2",
            "CargoBee",
            "Storm-4",
            "Scout-Lite"
        };
        public HashSet<string> ValidCategory = new()
        {
            "Recon",
            "Patrol",
            "Mapping",
            "Delivery",
            "Search"
        };
        public HashSet<string> ValidBaseLocation = new()
        {
            "North",
            "South",
            "Central",
            "East",
            "West"
        };
        public HashSet<string> ValidStatus = new()
        {
            "Operational",
            "Maintenance",
            "Grounded",
            "Training",
        };

    }
}