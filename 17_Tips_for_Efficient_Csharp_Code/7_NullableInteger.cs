using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class nullableIntegerf
    {
        void test()
        {
            // Good to use a nullable integer
            int? number = null;

            // Check if the value is null
            if (number.HasValue)
            {
                Console.WriteLine(number.Value);
            }
            else
            {
                Console.WriteLine("Number is null");
            }
        }
    }
}