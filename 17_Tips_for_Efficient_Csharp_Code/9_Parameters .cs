using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class parameters
    {
        // Bad example
            void DoSomething(ref int x, out int y)
            {
                x = 10;
                y = 20;
            }

            // Good example
            void DoSomething(int x, out int y)
            {
                y = x * 2;
            }
        }
    }
    

