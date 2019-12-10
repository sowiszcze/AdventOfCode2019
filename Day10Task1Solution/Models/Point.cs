using System;
using System.Collections.Generic;
using System.Text;

namespace Day10Task1Solution.Models
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
