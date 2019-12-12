using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day12Task1Solution.Models
{
    internal class Moon : Point3D
    {
        internal Moon(int x, int y, int z)
            : base(x, y, z)
        {
            Velocity = new Velocity(0, 0, 0);
        }

        internal Velocity Velocity { get; private set; }

        internal void ApplyVelocity()
        {
            X += Velocity.X;
            Y += Velocity.Y;
            Z += Velocity.Z;
        }

        internal int PotentialEnergy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        internal int Energy => PotentialEnergy * Velocity.KineticEnergy;
    }
}
