using Day15Task1Solution.Enums;
using Day15Task1Solution.Models;
using IntcodeInterpreter;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day15Task1Solution
{
    public class TraversalDroid
    {
        private readonly IList<MazePoint> maze;
        private readonly Interpreter interpreter;

        public TraversalDroid(long[] program)
        {
            maze = new List<MazePoint>();
            interpreter = new Interpreter(program);
            maze.Add(new MazePoint(0, 0, PointType.Corridor));
        }

        public void CreateMap()
        {
            long x = 0,
                y = 0;
            do
            {
                var blockedBy = 0;
                var openBy = MovementCommand.None;
                var current = maze.SingleOrDefault(p => p.X == x && p.Y == y);

                var north = maze.SingleOrDefault(p => p.X == x && p.Y == y - 1);
                if (north == null)
                {
                    var result = Move(MovementCommand.North);
                    north = new MazePoint(x, y - 1, result);
                    maze.Add(north);
                    if (result == PointType.OxygenSystem || result == PointType.Corridor)
                    {
                        y--;
                        continue;
                    }
                    blockedBy++;
                }
                else
                {
                    switch (north.Type)
                    {
                        case PointType.Corridor:
                        case PointType.OxygenSystem:
                            openBy = MovementCommand.North;
                            break;
                        case PointType.DeadEnd:
                        case PointType.Wall:
                            blockedBy++;
                            break;
                    }
                }

                var east = maze.SingleOrDefault(p => p.X == x + 1 && p.Y == y);
                if (east == null)
                {
                    var result = Move(MovementCommand.East);
                    east = new MazePoint(x + 1, y, result);
                    maze.Add(east);
                    if (result == PointType.OxygenSystem || result == PointType.Corridor)
                    {
                        x++;
                        continue;
                    }
                    blockedBy++;
                }
                else
                {
                    switch (east.Type)
                    {
                        case PointType.Corridor:
                        case PointType.OxygenSystem:
                            openBy = openBy == MovementCommand.None ? MovementCommand.East : openBy;
                            break;
                        case PointType.DeadEnd:
                        case PointType.Wall:
                            blockedBy++;
                            break;
                    }
                }

                var south = maze.SingleOrDefault(p => p.X == x && p.Y == y + 1);
                if (south == null)
                {
                    var result = Move(MovementCommand.South);
                    south = new MazePoint(x, y + 1, result);
                    maze.Add(south);
                    if (result == PointType.OxygenSystem || result == PointType.Corridor)
                    {
                        y++;
                        continue;
                    }
                    blockedBy++;
                }
                else
                {
                    switch (south.Type)
                    {
                        case PointType.Corridor:
                        case PointType.OxygenSystem:
                            openBy = openBy == MovementCommand.None ? MovementCommand.South : openBy;
                            break;
                        case PointType.DeadEnd:
                        case PointType.Wall:
                            blockedBy++;
                            break;
                    }
                }

                var west = maze.SingleOrDefault(p => p.X == x - 1 && p.Y == y);
                if (west == null)
                {
                    var result = Move(MovementCommand.West);
                    west = new MazePoint(x - 1, y, result);
                    maze.Add(west);
                    if (result == PointType.OxygenSystem || result == PointType.Corridor)
                    {
                        x--;
                        continue;
                    }
                    blockedBy++;
                }
                else
                {
                    switch (west.Type)
                    {
                        case PointType.Corridor:
                        case PointType.OxygenSystem:
                            openBy = openBy == MovementCommand.None ? MovementCommand.West : openBy;
                            break;
                        case PointType.DeadEnd:
                        case PointType.Wall:
                            blockedBy++;
                            break;
                    }
                }

                if (blockedBy == 3)
                {
                    current.SetType(PointType.DeadEnd);
                }
                else if (blockedBy == 4)
                {
                    break;
                }

                Move(openBy);
                switch (openBy)
                {
                    case MovementCommand.North:
                        y--;
                        break;
                    case MovementCommand.East:
                        x++;
                        break;
                    case MovementCommand.South:
                        y++;
                        break;
                    case MovementCommand.West:
                        x--;
                        break;
                    default:
                        throw new NotImplementedException($"Command {openBy} was not implemented.");
                }
            } while (maze.Any(p => p.Type == PointType.Corridor));
        }

        public string[] RenderMaze()
        {
            var render = new List<string>();

            for (long y = maze.Min(p => p.Y); y <= maze.Max(p => p.Y); y++)
            {
                var text = new StringBuilder();
                for (long x = maze.Min(p => p.X); x <= maze.Max(p => p.X); x++)
                {
                    var point = maze.SingleOrDefault(p => p.X == x && p.Y == y);
                    if (point != null)
                    {
                        switch (point.OriginalType)
                        {
                            case PointType.Corridor:
                                text.Append(" ");
                                break;
                            case PointType.DeadEnd:
                                text.Append("X");
                                break;
                            case PointType.OxygenSystem:
                                text.Append("O");
                                break;
                            case PointType.Wall:
                                text.Append("▓");
                                break;
                            default:
                                throw new NotImplementedException($"Point type {point.Type} was not implemented.");
                        }
                    }
                    else
                    {
                        text.Append("▓");
                    }
                }
                render.Add(text.ToString());
            }

            return render.ToArray();
        }

        public long TimeToFillWithOxygen()
        {
            return GetLongestOxygenPath(maze.Single(p => p.OriginalType == PointType.OxygenSystem)) - 1;
        }

        private PointType Move(MovementCommand command)
        {
            interpreter.ClearOutput();
            interpreter.AddInput((long)command);
            interpreter.Run();
            return (PointType)interpreter.Output.First();
        }

        private IEnumerable<MazePoint> GetNeighbours(PointLong reference)
        {
            return maze.Where(p =>
                p.X == reference.X && p.Y == reference.Y + 1 ||
                p.X == reference.X + 1 && p.Y == reference.Y ||
                p.X == reference.X && p.Y == reference.Y - 1 ||
                p.X == reference.X - 1 && p.Y == reference.Y);
        }

        private long GetLongestOxygenPath(MazePoint start)
        {
            IEnumerable<MazePoint> neighboursInNeed = new MazePoint[] { start };
            var counter = 0L;

            do
            {
                var currentPoint = neighboursInNeed.First();
                currentPoint.HasOxygen = true;
                counter++;
                neighboursInNeed = GetNeighbours(currentPoint).Where(p => p.NeedsOxygen);
            } while (neighboursInNeed.Count() == 1);

            if (neighboursInNeed.Count() == 0)
            {
                return counter;
            }

            return counter + neighboursInNeed.Max(GetLongestOxygenPath);
        }
    }
}
