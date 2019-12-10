﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day10Task1Solution.Models
{
    public class Vector
    {
        public Vector(int u, int v)
        {
            int gcd = GCD(Math.Abs(u), Math.Abs(v));
            U = u / gcd;
            V = v / gcd;
            Angle = ((Math.Atan2(V * -1, U * -1) / Math.PI) * 180.0 + 450.0) % 360;
        }

        public int U { get; private set; }
        public int V { get; private set; }
        public double Angle { get; private set; }

        public bool IsBlank => U == 0 && V == 0;
        public bool IsVertical => U == 0 && V != 0;
        public bool IsHorizontal => U != 0 && V == 0;

        private int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
    }
}
