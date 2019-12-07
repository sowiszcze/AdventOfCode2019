using Day03Task2Solution.Enums;
using Day03Task2Solution.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day03Task2Solution
{
    public static class Solution
    {
        public static IList<(char, int)> CreateDirectionsList(string input)
        {
            return input.Split(',').Select(e => (e[0], int.Parse(e.Substring(1)))).ToList();
        }

        public static IList<Line> CreateWire(IList<(char, int)> directions)
        {
            var wire = new List<Line>();
            foreach (var direction in directions)
            {
                wire.Add(new Line(wire.Count == 0 ? new Point(0, 0) : wire.Last().End, direction.Item1, direction.Item2));
            }
            return wire;
        }

        public static IEnumerable<int> GetInterestingIntersectionsLength(IList<Line> wire1, IList<Line> wire2)
        {
            int length1 = 0;
            foreach (var line1 in wire1)
            {
                int length2 = 0;
                foreach (var line2 in wire2)
                {
                    if (line1.Dimension == line2.Dimension)
                    {
                        length2 += line2.Length;
                        continue;
                    }

                    if (line1.Dimension == Dimension.Horizontal)
                    {
                        if (line2.Start.X < line1.GetMaxX() && line2.Start.X > line1.GetMinX() &&
                            line1.Start.Y < line2.GetMaxY() && line1.Start.Y > line2.GetMinY())
                        {
                            Point intersection = new Point(line2.Start.X, line1.Start.Y);
                            yield return length1 + line1.LengthUntilPoint(intersection) + length2 + line2.LengthUntilPoint(intersection);
                            break;
                        }
                    }
                    else if (line1.Dimension == Dimension.Vertical)
                    {
                        if (line2.Start.Y < line1.GetMaxY() && line2.Start.Y > line1.GetMinY() &&
                            line1.Start.X < line2.GetMaxX() && line1.Start.X > line2.GetMinX())
                        {
                            Point intersection = new Point(line1.Start.X, line2.Start.Y);
                            yield return length1 + line1.LengthUntilPoint(intersection) + length2 + line2.LengthUntilPoint(intersection);
                            break;
                        }
                    }

                    length2 += line2.Length;
                }
                length1 += line1.Length;
            }
        }
    }
}
