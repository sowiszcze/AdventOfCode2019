using Day13Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day13Task1Solution.Models
{
    public class Tile : PointLong
    {
        public Tile(long x, long y, TileId id)
            : base(x, y)
        {
            Id = id;
        }

        public TileId Id { get; private set; }
    }
}
