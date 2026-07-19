namespace DroneFleetDataProcessing.customexceptions;

class UnserelazeblleDataException:Exception
{
    public UnserelazeblleDataException(string exception) : base(exception) { }
}

class NoDroneReportDataException : Exception
{
    public NoDroneReportDataException(string exception) : base(exception) { }
}

class AllDataIsInvalidException : Exception
{
    public AllDataIsInvalidException(string exception) : base(exception) { }
}
