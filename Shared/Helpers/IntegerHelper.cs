using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public static class IntegerHelper
    {
        public static long GCD(long a, long b)
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

        public static int GCD(int a, int b)
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

        public static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }

        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }
    }
}
