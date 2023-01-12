using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    public class StringFormat
    {
        string FullName()
        {

            // Bad example
            string firstName = "John";
            string lastName = "Doe";
            string fullName = firstName + " " + lastName;

            return fullName;
        }

        string FullName_format()
        {
            // Good example
            string firstName = "John";
            string lastName = "Doe";
            string fullName = string.Format("{0} {1}", firstName, lastName);
            return fullName;
        }
    }
}
