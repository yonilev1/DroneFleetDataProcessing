using DroneFleetDataProcessing.drone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ReportGenerator
{
    private int _allDataLen;
    private string _outPutPath;
    private List<Drone> _drones;

    public ReportGenerator(string outPutPath, int allDataLen, List<Drone> drones)
    {
        _outPutPath = outPutPath;
        _allDataLen = allDataLen;
        _drones = drones;
    }
    public void Execute()
    {
        File.WriteAllText(_outPutPath,
            "DRONE FLEET ANALYSIS REPORT\n\n" +
            "PROCESSING SUMMARY\n" +
            "Total raw records: " + _allDataLen + "\n" +
            "Valid records: " + _drones.Count + "\n" +
            "Rejected records: " + RegectedData() + "\n\n" +
            "NON-OPERATIONAL DRONES\n");


        var nonOperational = OnOperations();

        if (nonOperational.Any())
        {
            foreach (string drone in nonOperational)
            {
                File.AppendAllText(_outPutPath, $"{drone}\n");
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }

        File.AppendAllText(_outPutPath, "\n");


        File.AppendAllText(_outPutPath, "TOP 5 DRONES BY FLIGHT HOURS\n");

        var topDrones = TopFiveFlingHours();

        if (topDrones.Any())
        {
            int count = 1;

            foreach (string item in topDrones)
            {
                File.AppendAllText(_outPutPath, $"{count}. {item}\n");
                count++;
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }

        File.AppendAllText(_outPutPath, "\n");


        File.AppendAllText(_outPutPath, "AVAILABLE DRONE MODELS\n");

        var types = GetAllDitictTyps();

        if (types.Any())
        {
            foreach (string type in types)
            {
                File.AppendAllText(_outPutPath, $"{type}\n");
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }

        File.AppendAllText(_outPutPath, "\n");


        File.AppendAllText(_outPutPath, "DRONES BY BASE\n");

        var bases = GetNumberOfdronsPerbase();

        if (bases.Any())
        {
            foreach (string item in bases)
            {
                File.AppendAllText(_outPutPath, $"{item}\n");
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }

        File.AppendAllText(_outPutPath, "\n");


        File.AppendAllText(_outPutPath, "AVERAGE BATTERY HEALTH BY MODEL\n");

        var battery = AverageBatteryByType();

        if (battery.Any())
        {
            foreach (string item in battery)
            {
                File.AppendAllText(_outPutPath, $"{item}\n");
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }

        File.AppendAllText(_outPutPath, "\n");


        File.AppendAllText(_outPutPath,
            "MODEL WITH HIGHEST TOTAL COMPLETED MISSIONS\n");

        var (topModel, missions) = GetModelWithMostCompletedTasks();

        if (topModel != null)
        {
            File.AppendAllText(_outPutPath, $"Model: {topModel}\n");
            File.AppendAllText(_outPutPath,
                $"Total completed missions: {missions}\n\n");
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n\n");
        }


        File.AppendAllText(_outPutPath,
            "SELECTED ADDITIONAL ANALYSIS\n");

        File.AppendAllText(_outPutPath,
            "Analysis name: Bases with Operational Drones (Battery > 80%)\n");


        var analysis = GetBasesWithOperationalDronesBatteryAbove80();

        if (analysis.Any())
        {
            foreach (var baseLocation in analysis)
            {
                File.AppendAllText(_outPutPath, $"- {baseLocation}\n");
            }
        }
        else
        {
            File.AppendAllText(_outPutPath, "No results found\n");
        }


        Console.WriteLine("Step 5: Performing analysis... Analysis completed successfully");
        Console.WriteLine($"Step 6: Generating report... Report generated successfully: {_outPutPath}");
    }

    private IEnumerable<string> OnOperations()
    {
        return _drones
            .Where(d => d.status != "Operational")
            .Select(d => $"{d.serialNumber} | {d.model} | {d.base_location} | {d.status}");
    }

    private IEnumerable<string> TopFiveFlingHours()
    {
        return _drones
            .OrderByDescending(d => d.flightHours)
            .Take(5)
            .Select(d => $"{d.serialNumber} | {d.model} | {d.flightHours}");
    }

    private int RegectedData()
    {
        return _allDataLen - _drones.Count;
    }

    private IEnumerable<string> GetAllDitictTyps()
    {
        return _drones.Select(d => d.model).Distinct();
    }

    private IEnumerable<string> GetNumberOfdronsPerbase()
    {
        return _drones
            .GroupBy(d => d.base_location)
            .Select(b => $"{b.Key}: {b.Count()}");
    }

    private IEnumerable<string> AverageBatteryByType()
    {
        return _drones
            .GroupBy(d => d.model)
            .Select(g => $"{g.Key}: {g.Average(d => d.batteryHealth):F1}%");
    }

    private (string Model, int? TaskCount) GetModelWithMostCompletedTasks()
    {
        var result = _drones
            .GroupBy(d => d.model)
            .Select(g => new
            {
                Model = g.Key,
                TotalCompleted = g.Sum(d => d.missionsCompleted)
            })
            .OrderByDescending(r => r.TotalCompleted)
            .FirstOrDefault();

        return result != null ? (result.Model, result.TotalCompleted) : ("None", 0);
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