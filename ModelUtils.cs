using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModel_Gen
{
    public static class ModelUtils
    {
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        public static double GetDistance(Node first, Node second)
        {
            return GetDistance(first.GridX, first.GridY, second.GridX, second.GridY);
        }
    }
}
