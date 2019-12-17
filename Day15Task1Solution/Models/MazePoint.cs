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
            HasOxygen = false;
            Type = type;
            OriginalType = type;
        }

        internal PointType Type { get; private set; }
        internal PointType OriginalType { get; private set; }

        internal void SetType(PointType type)
        {
            Type = type;
        }

        public bool HasOxygen { get; set; }
        public bool NeedsOxygen => !HasOxygen && OriginalType == PointType.Corridor;
    }
}
