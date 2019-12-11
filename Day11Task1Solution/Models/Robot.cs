using Day11Task1Solution.Enums;
using Shared.Models;
using System;

namespace Day11Task1Solution.Models
{
    internal class Robot : Point
    {
        internal Robot()
            : base(0, 0)
        {
        }

        internal void RoateAndMove(Rotation rotation)
        {
            int diff;
            switch (rotation)
            {
                case Rotation.Left90:
                    diff = -90;
                    break;
                case Rotation.Right90:
                    diff = 90;
                    break;
                default:
                    throw new NotImplementedException($"Rotation {rotation} is not imlpemented.");
            }

            Direction = (Direction)(((int)Direction + 360 + diff) % 360);

            switch (Direction)
            {
                case Direction.Up:
                    Y++;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Down:
                    Y--;
                    break;
                case Direction.Left:
                    X--;
                    break;
                default:
                    throw new NotImplementedException($"Direction {Direction} is not implemented.");
            }
        }

        public Direction Direction { get; private set; }
    }
}
