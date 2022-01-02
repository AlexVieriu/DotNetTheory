using Autofac;
using System.Reflection;

namespace TimCorey_DI_with_Autofac;

public class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        
        // map interface to object
        builder.RegisterType<Application>().As<IApplication>(); 
        builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();// 13:30
        builder.RegisterType<BetterBusinessLogic>().As<IBusinessLogic>();// 41:49

        // map all classes to the interfaces in Utilities folder
        builder.RegisterAssemblyTypes(Assembly.Load(nameof(TimCorey_DI_with_Autofac)))
               .Where(t => t.Namespace.Contains("Utilities"))
               .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

        return builder.Build();
    }
}

