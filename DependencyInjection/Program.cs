using NickChapsas_DI;
using NickChapsas_DI.DI;


var services = new DiServiceCollection();


//services.RegisterSingleton(new RandomGuidGenerator());
//services.RegisterSingleton<RandomGuidGenerator>();
//services.RegisterTransient<RandomGuidGenerator>();

//services.RegisterTransient<ISomeService, ServiceOne>();

var container = services.GenerateContainer();

var serviceFirst = container.GetService<RandomGuidGenerator>();
var serviceSecond = container.GetService<RandomGuidGenerator>();

Console.WriteLine(serviceFirst.RandomGuid);
Console.WriteLine(serviceSecond.RandomGuid);
