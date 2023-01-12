using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTips
{
    
    // Bad example for lightweight useage 
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Good example
    struct point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
