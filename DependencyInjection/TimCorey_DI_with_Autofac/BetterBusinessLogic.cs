using TimCorey_DI_with_Autofac.Utilities;

namespace TimCorey_DI_with_Autofac;

public class BetterBusinessLogic : IBusinessLogic
{
    private readonly ILogger _logger;
    private readonly IDataAccess _dataAccess;

    public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    public void ProcessData()
    {
        _logger.Log("I changed the implementation of the BusinessLogic with BetterBusinessLogic");
        _dataAccess.LoadData();
        _dataAccess.SaveData("We are saving the data");
    }
}

