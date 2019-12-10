using System;
using System.Collections.Generic;
using System.Text;

namespace Day10Task1Solution.Models
{
    public class Asteroid : Point
    {
        public Asteroid(int x, int y)
            :base(x, y)
        {
        }

        public bool IsPlacedAt(Point point)
        {
            return X == point.X && Y == point.Y;
        }

        public Vector CalculateVector(Asteroid other)
        {
            return new Vector(X - other.X, Y - other.Y);
        }

        public IEnumerable<Point> GetMiddlePoints(Asteroid other)
        {
            var vector = CalculateVector(other);
            if (!vector.IsBlank)
            {
                for (var i = 1; ; i++)
                {
                    var point = new Point(other.X + vector.U * i, other.Y + vector.V * i);
                    if (IsPlacedAt(point))
                    {
                        break;
                    }
                    yield return point;
                }
            }
        }
    }
}
