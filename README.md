# Drone Fleet Data Processing System

## background

A military drone unit receives a raw data file every day from an external sensor system. 
The file contains information on about 100 drones operating at various bases across the country. 
The external system is not entirely reliable: the overall structure of the file is syntactically correct and readable, 
but some of the records contain values ​​that do not meet the unit's standards.

1. Receives information
2. Verifies information
3. Serializes verified information
4. Processes information and extracts information from a new document
5. Amends deletions

------------------------------------------
## Possible code obstacles
1. Handling errors and exceptions
2. Formulating queries

-----------------------------------------------
## project folder structure
```text
DroneFleetDataProcessing/
├── input/
│   ├── raw/
│   │   └── drones_raw.json
│   └── test_scenarios/
│       ├── drones_malformed.json
│       ├── drones_empty.json
│       ├── drones_null.json
│       └── drones_all_invalid.json
├── output/
│   ├── drones_clean.json (created at runtime)
│   └── analysis_report.txt (created at runtime)
├── src/
│   ├── Drone
|       └── Drone.cs
|   ├── Exceptions
|       └── CustomExceptions.cs
|   ├── IReader
|		└──IReader.cs 
|   ├── PipLine
|		└── PipLine.cs
|   ├── Reader
|		└── Reader.cs
|   └──  Validator
|		├── Validator.cs
|		└── Set.cs
└── README.md
```

----------------------------------------------------
## project components
interface IReader \
class Drone \
class ReadJson \
class Pipline \
class CustomExseptions \
class ReportGenerait \
class Validator \
class Program

--------------------------------------------

## component responsibility

### interface IReader
Requires the implementation of the "GetData" function,\
exists for easily changing the type of data source

### class Drone
creation of a Drone object from information \
received from an external data source \

#### propertis
public int id { get; set; } \
public string serialNumber { get; set; } \
public string model { get; set; } \
public string category { get; set; } \
public string base_location { get; set; } \
public double flightHours { get; set; } \
public int batteryHealth { get; set; } \
public double maxRangeKm { get; set; } \
public int missionsCompleted { get; set; } \
public string status { get; set; }

-----------------------------------------------------
### class JsonRead
implements the "IReader" interface

#### Methods: 
public string GetData(string path)

----------------------------------------------------------
### class Pipline
It runs the code of all commands in order, \
including checking the received data and extracting specific data from the file.

#### Fils:
string InputFilePath \
string OutputPath \
validator \
ValidDroneReports

#### Constractor:
validator

#### Methods:
WriteNewFile \
ExecutePipeline

----------------------------------------
### CustomExseptions
includes all created unacceptable errors such as unacceptable text and the like

#### Exseptions:
class unserelazeblle \
class NoData \
class allDataInvalid 

-------------------------------------------
### class ReportGenerator
executes queries and returns a full statistics report

#### constractor:
AllDataLen

#### Fils:
List type Dron \
outPutPath

#### Method:
public void Execute() \
private string OnOperations() \
private int CountValidData() \
private string TopFiveFlingHours() \
private string GetAllDitictTyps() \
private string GetNumberOfdronsPerbase() \
private string AvergeBetteryByType() \
private string GetModelWithMostConpliteTasks() \
private string GetBasesWithOperationalDronesBatteryAbove80() \
private string GetThreeModelsWithHighestAverageFlightHours()

-----------------------------------------------
### class Validator
checks whether the drone object is valid.

#### constractor:
private List type:Drone _validatedDrones;

#### Methods:
public bool Excecute(Dronr drone) \
private bool IsValidId(Int id) \
private bool Isvalid SerialNumber(string SN) \
private bool IsValidModel(string model) \
private bool IsValidCategory(string category) \
private bool isValidBaseLocatoins(string baseLocations) \
private bool isValidFlithHours(duble flithHours) \
private bool isValidBaterryHelth(int baterryHlth) \
private bool isValidMaxRenge(int maxRenge) \
private bool isValidMissionsCompleted(int missionsCompleted) \
private bool isValidStatus(string status)

---------------------------------------------------------
### class Program
Work floow meneger

-----------------------------------------------------
## Communication between components
Main uses Reader \
Main uses Pipeline \
Main uses Report \
Jason Read and Validator use exceptions \
Pipeline creates a drone object

---------------------------------------------------------
## division of work

#### Yoni
Ireder \
Reder \
Exseptions

#### Mordechai
class Drone \
class Pipline

#### Meir
README \
class Validations

------------------------------------------------------------
## Why we chose this design
To comply with the "SOLID" rules, the system is protected 
from errors; each problem has its own error.