using BenchmarkDotNet.Attributes;
using Castle.DynamicProxy;
using TechTalks.Castle.Aspects;
using TechTalks.Castle.Impl;

namespace TechTalks.Castle.Benchmark
{
    [MemoryDiagnoser]
    public class DecoratorBenchmarker
    {
        private IMyService _myService;

        [Params(10, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            //SetupImplicit();
            SetupAspect();
        }

        private void SetupImplicit()
        {
            _myService = new MyServiceTrace(new MyService());
        }

        private void SetupAspect()
        {
            IProxyGenerator generator = new ProxyGenerator();
            var myInterseptor = new TraceInterseptor();
            var myService = new MyService();
            _myService = generator.CreateInterfaceProxyWithTarget<IMyService>(myService, myInterseptor);
        }

        [Benchmark(Description = "Implicit")]
        //[Benchmark(Description = "Aspect")]
        public void Benchmark()
        {
            for (int i = 0; i < Count; i++)
            {
                _myService.DoOperation();
            }
        }
    }
}
