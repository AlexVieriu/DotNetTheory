namespace NickChapsas_DI;

public class ServiceOne : ISomeService
{
    private readonly Guid RandomGuid = Guid.NewGuid();  

    public void PrintSomething()
    {
        Console.WriteLine(RandomGuid);
    }
}

