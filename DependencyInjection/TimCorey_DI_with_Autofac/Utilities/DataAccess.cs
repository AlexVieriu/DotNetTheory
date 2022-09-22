namespace TimCorey_DI_with_Autofac.Utilities;

public class DataAccess : IDataAccess
{
    private readonly ILogger _logger;

    public DataAccess(ILogger logger)
    {
        _logger = logger;
    }

    public void LoadData()
    {
        Console.WriteLine("Loading Data");
        _logger.Log("Loading Data");
    }

    public void SaveData(string name)
    {
        Console.WriteLine($"{name}");
        _logger.Log("Saving Data");
    }
        
}

