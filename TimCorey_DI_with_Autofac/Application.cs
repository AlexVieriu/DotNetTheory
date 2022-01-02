namespace TimCorey_DI_with_Autofac;

public class Application : IApplication
{
    private readonly IBusinessLogic _business;

    public Application(IBusinessLogic business)
    {
        _business = business;
    }

    public void Run()
    {
        _business.ProcessData();
    }
}

