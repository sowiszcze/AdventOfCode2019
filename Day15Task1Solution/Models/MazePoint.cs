using Day15Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day15Task1Solution.Models
{
    internal class MazePoint : PointLong
    {
        internal MazePoint(long x, long y, PointType type)
            : base(x, y)
        {
            Type = type;
        }

        internal PointType Type { get; private set; }

        internal void SetType(PointType type)
        {
            Type = type;
        }
    }
}
