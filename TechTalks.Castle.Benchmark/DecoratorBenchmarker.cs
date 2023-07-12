using BenchmarkDotNet.Attributes;
using Castle.DynamicProxy;
using TechTalks.Castle.Aspects;
using TechTalks.Castle.Impl;

namespace TechTalks.Castle.Benchmark
{
    [MemoryDiagnoser]
    public class DecoratorBenchmarker
    {
        private IMyService _myServiceImplicit;
        private IMyService _myServiceAspect;

        [Params(10, 100)]
        public int Count { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupImplicit();
            SetupAspect();
        }

        private void SetupImplicit()
        {
            _myServiceImplicit = new MyServiceTrace(new MyService());
        }

        private void SetupAspect()
        {
            IProxyGenerator generator = new ProxyGenerator();
            var myInterseptor = new TraceInterseptor();
            var myService = new MyService();
            _myServiceAspect = generator.CreateInterfaceProxyWithTarget<IMyService>(myService, myInterseptor);
        }

        [Benchmark(Description = "Implicit")]
        public void BenchmarkImplicit()
        {
            for (int i = 0; i < Count; i++)
            {
                _myServiceImplicit.DoOperation();
            }
        }

        [Benchmark(Description = "Aspect")]
        public void BenchmarkAspect()
        {
            for (int i = 0; i < Count; i++)
            {
                _myServiceAspect.DoOperation();
            }
        }
    }
}
