using TimCorey_DI_with_Autofac.Utilities;

namespace TimCorey_DI_with_Autofac;

public class BusinessLogic : IBusinessLogic
{
    private readonly ILogger _logger;
    private readonly IDataAccess _data;

    public BusinessLogic(ILogger logger, IDataAccess data) // constructor injection
    {
        _logger = logger;
        _data = data;
    }

    public void ProcessData()
    {
        _logger.Log("Starting the processing of data.");
        Console.WriteLine("Processing the data");
        _data.LoadData();
        _data.SaveData("ProcessedInfo");
        _logger.Log("Finished processing of the data");
    }
}

