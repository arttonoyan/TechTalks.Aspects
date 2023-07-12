using Microsoft.Extensions.DependencyInjection;
using TechTalks.Castle;
using TechTalks.Castle.Aspects;
using TechTalks.Castle.Impl;

var services = new ServiceCollection();

//services.AddScoped<MyService>();
//services.AddScoped<IMyService>(p => { 
//    var myService = p.GetRequiredService<MyService>();
//    return new MyServiceTrace(myService);
//});
services.AddScoped<IMyService, MyService, TraceInterseptor>();

var provider = services.BuildServiceProvider();

var myService = provider.GetRequiredService<IMyService>();
myService.DoOperation();
Console.WriteLine("-----------------------");
myService.DoOperation();

Console.ReadLine();