namespace NickChapsas_DI.DI;

public class ServiceDescriptor
{
    public Type ServiceType { get; }
    public object Implementation { get; internal set; }
    public ServiceLifetime Lifetime { get; }

    public ServiceDescriptor(object implemantation, ServiceLifetime lifetime)
    {
        ServiceType = implemantation.GetType();
        Implementation = implemantation;
        Lifetime = lifetime;
    }

    public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        Lifetime = lifetime;
    }
}

