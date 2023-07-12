namespace TechTalks.Castle.Impl;

public class MyService : IMyService
{
    private int _count;

    public void DoOperation()
    {
        _count++;
        //Console.WriteLine($"MyService Count: {_count}");
    }
}
