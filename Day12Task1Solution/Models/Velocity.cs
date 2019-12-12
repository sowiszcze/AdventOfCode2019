using Shared.Models;
using System;
using Shared.Extensions;
using System.Text;

namespace Day12Task1Solution.Models
{
    internal class Velocity : Point3D
    {
        internal Velocity(int x, int y, int z)
            : base(x, y, z)
        {
        }

        internal void Adapt(Point3D source, Point3D reference)
        {
            X += (reference.X - source.X).Normalize();
            Y += (reference.Y - source.Y).Normalize();
            Z += (reference.Z - source.Z).Normalize();
        }

        internal int KineticEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
    }
}
