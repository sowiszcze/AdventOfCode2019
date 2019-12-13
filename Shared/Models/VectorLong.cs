using Shared.Helpers;
using System;

namespace Shared.Models
{
    public class VectorLong
    {
        private readonly long gcd;

        public VectorLong(long u, long v)
            : this(u, v, true)
        {
        }

        public VectorLong(long u, long v, bool normalize)
        {
            gcd = IntegerHelper.GCD(Math.Abs(u), Math.Abs(v));
            IsNormalized = normalize || gcd == 1;
            gcd = normalize ? gcd : 1;
            U = u / gcd;
            V = v / gcd;
            Angle = ((Math.Atan2(V * -1, U * -1) / Math.PI) * 180.0 + 450.0) % 360;
        }

        public long U { get; private set; }
        public long V { get; private set; }
        public double Angle { get; private set; }
        public bool IsNormalized { get; private set; }

        public bool IsBlank => U == 0 && V == 0;
        public bool IsVertical => U == 0 && V != 0;
        public bool IsHorizontal => U != 0 && V == 0;

        public void Normalize()
        {
            if (!IsNormalized)
            {
                U /= gcd;
                V /= gcd;
                IsNormalized = true;
            }
        }
    }
}
