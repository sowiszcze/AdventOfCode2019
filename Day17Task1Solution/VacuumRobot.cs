using Day17Task1Solution.Enums;
using Day17Task1Solution.Models;
using IntcodeInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day17Task1Solution
{
    public class VacuumRobot
    {
        private readonly Interpreter ascii;
        private readonly List<MapPoint> mapPoints;

        private VacuumRobot(long[] asciiProgram)
        {
            ascii = new Interpreter(asciiProgram);
            mapPoints = new List<MapPoint>();
        }

        public static VacuumRobot Create(long[] asciiProgram)
        {
            return new VacuumRobot(asciiProgram);
        }

        public static VacuumRobot CreateHacked(long[] asciiProgram)
        {
            var hacked = asciiProgram.Clone() as long[];
            hacked[0] = 2;
            return new VacuumRobot(hacked);
        }

        public string RenderedMap { get; private set; }

        public void Scan()
        {
            ascii.Run();
            RenderedMap = new string(ascii.Output.Select(o => (char)o).ToArray());
            ReadMapPoints();
        }

        public long Broadcast(string input)
        {
            ascii.AddInput(input.ToCharArray().Select(c => (long)c).ToArray());
            ascii.Run();
            return ascii.Output.Last();
        }

        public long Calibrate()
        {
            var counter = 0L;
            var scaffoldTypes = new PointType[]
            {
                PointType.RobotEast,
                PointType.RobotNorth,
                PointType.RobotSouth,
                PointType.RobotWest,
                PointType.Scaffold
            };

            foreach (var point in mapPoints.Where(p => scaffoldTypes.Contains(p.Type)))
            {
                var neighbours = new MapPoint[]
                {
                    mapPoints.SingleOrDefault(p => p.X == point.X - 1 && p.Y == point.Y),
                    mapPoints.SingleOrDefault(p => p.X == point.X + 1 && p.Y == point.Y),
                    mapPoints.SingleOrDefault(p => p.X == point.X && p.Y == point.Y - 1),
                    mapPoints.SingleOrDefault(p => p.X == point.X && p.Y == point.Y + 1)
                }.Count(p => p != null && scaffoldTypes.Contains(p.Type));

                if (neighbours > 2)
                {
                    counter += point.X * point.Y;
                }
            }
            return counter;
        }

        private void ReadMapPoints()
        {
            long x = 0,
                y = 0;

            foreach (var output in ascii.Output)
            {
                var type = (PointType)output;
                if (type == PointType.EOL)
                {
                    x = 0;
                    y++;
                    continue;
                }
                mapPoints.Add(new MapPoint(x++, y, type));
            }
        }
    }
}
