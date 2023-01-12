using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class stringbuilders
    {
        void tes()
        {
            // Bad example
            string result = "";
            for (int i = 0; i < 100; i++)
            {
                result += i.ToString();
            }

            // Good example
            StringBuilder resultc = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                resultc.Append(i.ToString());

            }
        }
    }
}