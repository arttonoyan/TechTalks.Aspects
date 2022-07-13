using Castle.DynamicProxy;
using System.Diagnostics;

namespace TechTalks.Castle.Aspects
{
    public class TraceInterseptor : IInterceptor
    {
        private readonly Stopwatch _stopwatch;

        public TraceInterseptor()
        {
            _stopwatch = new Stopwatch();
        }

        public void Intercept(IInvocation invocation)
        {
            _stopwatch.Start();
            invocation.Proceed();
            _stopwatch.Stop();
        }
    }
}
