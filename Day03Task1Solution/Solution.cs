using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day03Task1Solution
{
    public static class Solution
    {
        public static IList<(char, int)> CreateCommandsList(string input)
        {
            return input.Split(',').Select(e => (e[0], int.Parse(e.Substring(1)))).ToList();
        }

        public static IEnumerable<Point> CreatePaths(IList<(char, int)> commands)
        {
            var currentPoint = new Point(0, 0);
            var path = new List<Point>();
            foreach (var command in commands)
            {
                int xModifier = 0,
                    yModifier = 0;

                switch (command.Item1)
                {
                    case 'U':
                        yModifier = 1;
                        break;
                    case 'D':
                        yModifier = -1;
                        break;
                    case 'R':
                        xModifier = 1;
                        break;
                    case 'L':
                        xModifier = -1;
                        break;
                    default:
                        throw new NotImplementedException($"Command {command.Item1} was not implemented.");
                }

                for (int i = 0; i < command.Item2; i++)
                {
                    currentPoint = new Point(currentPoint.X + xModifier, currentPoint.Y + yModifier);
                    path.Add(currentPoint);
                }
            }
            return path;
        }

        public static IEnumerable<Point> FindIntersections(IEnumerable<Point> path1, IEnumerable<Point> path2)
        {
            return path1.Where(p1 => path2.Any(p2 => p1.X == p2.X && p1.Y == p2.Y));
        }

        public static Point FindClosest(this IEnumerable<Point> intersections)
        {
            return intersections.OrderBy(p => Math.Abs(p.X) + Math.Abs(p.Y)).First();
        }

        public static int GetDistance(this Point intersection)
        {
            return Math.Abs(intersection.X) + Math.Abs(intersection.Y);
        }
    }
}
