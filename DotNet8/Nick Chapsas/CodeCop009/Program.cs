// https://www.youtube.com/watch?v=cTdaRX0vQuk&list=TLPQMTEwMjIwMjQDepYmoiUwlA&index=5&ab_channel=NickChapsas
// Singleton 

using static System.Console;
using CodeCop009;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

WriteLine(Singleton.Instance.GetHashCode());
WriteLine(Singleton.Instance.GetHashCode());


/******2nd example************/
// var builder = Host.CreateApplicationBuilder();
// builder.Services.AddSingleton<SomeClass>();

// var app = builder.Build();

// app.Run();

/******3rd example************/
var gameManager = GameManager.Instance;
