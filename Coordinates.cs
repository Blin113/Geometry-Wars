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
        public static T[] CreateCoordinatesArray(T x, T y)
        {
            return new T[] { x, y };
        }
    }
}
