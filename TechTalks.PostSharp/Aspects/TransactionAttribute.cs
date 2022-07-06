using PostSharp.Aspects;
using System.Transactions;

namespace TechTalks.PostSharp.Aspects
{
    [Serializable]
    public class TransactionAttribute : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            using var scope = new TransactionScope();
            args.Proceed();
            scope.Complete();
        }
    }
}
