using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Point3D : Point
    {
        public Point3D(int x, int y, int z)
            : base(x, y)
        {
            Z = z;
        }

        public int Z { get; protected set; }
    }
}
