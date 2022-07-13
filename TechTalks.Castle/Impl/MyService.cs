using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTalks.Castle.Impl
{
    public class MyService : IMyService
    {
        private int _count;

        public void DoOperation()
        {
            _count++;
        }
    }
}
