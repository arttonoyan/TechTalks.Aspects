using System.Diagnostics;

namespace TechTalks.Castle.Impl;

public class MyServiceTrace : IMyService
{
    private readonly IMyService _myService;
    private readonly Stopwatch _stopwatch;

    public MyServiceTrace(IMyService myService)
    {
        _myService = myService;
        _stopwatch = new Stopwatch();
    }

    public void DoOperation()
    {
        _stopwatch.Start();
        _myService.DoOperation();
        _stopwatch.Stop();
        //Console.WriteLine(_stopwatch.ElapsedMilliseconds);
    }
}
