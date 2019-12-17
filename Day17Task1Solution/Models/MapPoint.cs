using Day17Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day17Task1Solution.Models
{
    internal class MapPoint : PointLong
    {
        internal MapPoint(long x, long y, PointType type)
            : base(x, y)
        {
            Type = type;
        }

        internal PointType Type { get; private set; }
    }
}
