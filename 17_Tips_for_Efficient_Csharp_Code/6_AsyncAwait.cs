using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class AsyncAwait
    {
        // Bad example

         void StartProcess(object sender)
        {
            // Do some work
             Task.Delay(1000);
            // Do some more work
        }

        // good to use 
        async void Start_Process(object sender )
        {
            // Do some work
            await Task.Delay(1000);
            // Do some more work
        }
    }
    }
    

