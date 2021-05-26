using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Coordinates<T>
    {
        public static T[] CreateCoordinatesArray<T>(T x, T y)       //tekniskt sett är det en generisk metod....
        {
            return new T[] { x, y };
        }
    }
}
