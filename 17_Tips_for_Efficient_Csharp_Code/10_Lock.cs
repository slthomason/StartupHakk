using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class Lock
    {

        // Bad example 
        private object _lockObject = new object();

        void DoSomething()
        {
            lock (_lockObject)
            {
                // Critical section of code
            }
        }

    }
}