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
                do
                {
                    var point = new Point(other.X + vector.U, other.Y + vector.V);
                    if (IsPlacedAt(point))
                    {
                        break;
                    }
                    yield return point;
                } while (true);
            }
        }
    }
}
