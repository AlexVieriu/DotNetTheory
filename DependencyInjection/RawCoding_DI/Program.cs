// DI: we will create a little container where we register all our services that manages the creation
public class Program
{
    public static void Main(string[] args)
    {
        var service = (Service)Activator.CreateInstance(typeof(Service));
        var consumer = (ServiceConsumer)Activator.CreateInstance(typeof(ServiceConsumer), service);

        service.Print();
        consumer.Print();
    }
}

public class ServiceConsumer
{
    Service _hello;
    public ServiceConsumer(Service hello)
    {
        _hello = hello;
    }

    public void Print()
      => _hello.Print();
}

public class Service
{
    public void Print()
        => Console.WriteLine("Hello World");
}



