using Day03Task2Solution.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Day03Task2Solution.Models
{
    public class Line
    {
        public Line(Point start, char direction, int length)
        {
            Start = start;
            End = CalculateEnd(start, direction, length);
            Length = length;
        }

        public Dimension Dimension { get; private set; }
        public int Length { get; private set; }
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public int GetMinX() => Math.Min(Start.X, End.X);
        public int GetMinY() => Math.Min(Start.Y, End.Y);
        public int GetMaxX() => Math.Max(Start.X, End.X);
        public int GetMaxY() => Math.Max(Start.Y, End.Y);

        public int LengthUntilPoint(Point intersection)
        {
            switch (Dimension)
            {
                case Dimension.Vertical:
                    if (intersection.X != Start.X || intersection.Y < GetMinY() || intersection.Y > GetMaxY())
                    {
                        throw new Exception($"Line {Start.X},{End.X}:{End.X},{End.Y} does not contain point {intersection.X},{intersection.Y}.");
                    }
                    return Math.Abs(intersection.Y - Start.Y);
                case Dimension.Horizontal:
                    if (intersection.Y != Start.Y || intersection.X < GetMinX() || intersection.X > GetMaxX())
                    {
                        throw new Exception($"Line {Start.X},{End.X}:{End.X},{End.Y} does not contain point {intersection.X},{intersection.Y}.");
                    }
                    return Math.Abs(intersection.X - Start.X);
                default:
                    throw new NotImplementedException($"Dimension {Dimension} is not implemented.");
            }
        }

        private Point CalculateEnd(Point start, char direction, int length)
        {
            var end = new Point(start.X, start.Y);

            switch (direction)
            {
                case 'U':
                    end.Y += length;
                    Dimension = Dimension.Vertical;
                    break;
                case 'D':
                    end.Y -= length;
                    Dimension = Dimension.Vertical;
                    break;
                case 'R':
                    end.X += length;
                    Dimension = Dimension.Horizontal;
                    break;
                case 'L':
                    end.X -= length;
                    Dimension = Dimension.Horizontal;
                    break;
                default:
                    throw new NotImplementedException($"Direction {direction} is not implemented.");
            }

            return end;
        }
    }
}
