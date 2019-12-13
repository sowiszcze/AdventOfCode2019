using Day13Task1Solution.Enums;
using Day13Task1Solution.Models;
using IntcodeInterpreter;
using IntcodeInterpreter.Enums;
using Shared.Extensions;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day13Task1Solution
{
    public static class Solution
    {
        public static IEnumerable<Tile> Build(long[] program)
        {
            var interpreter = new Interpreter(program);
            interpreter.Run();
            return interpreter.Output
                .Select((o, i) => (o, i))
                .GroupBy(e => Convert.ToInt32(Math.Floor(e.i / 3.0)))
                .Select(g => new Tile(g.ElementAt(0).o, g.ElementAt(1).o, (TileId)g.ElementAt(2).o))
                .ToArray();
        }

        public static int CountBlocks(IEnumerable<Tile> tiles)
        {
            return tiles.Count(t => t.Id == TileId.Block);
        }

        public static long[] Crack(long[] program)
        {
            var cracked = program.Clone() as long[];
            cracked[0] = 2;
            return cracked;
        }

        public static long Simulate(long[] program)
        {
            var interpreter = new Interpreter(program);
            var ballPositions = new List<PointLong>();

            long score = 0;
            var tiles = new List<Tile>();

            do
            {
                interpreter.Run();
                var (newTiles, newScore) = interpreter.Output.Parse();
                if (newScore.HasValue)
                {
                    score = newScore.Value;
                }
                UpdateTiles(tiles, newTiles);
                interpreter.ClearOutput();
                interpreter.AddInput((long)UseJoystickSimple(tiles, ballPositions));
            } while ((interpreter.Status == Status.NeedsMoreInput || tiles.Any(t => t.Id == TileId.Block)) && !tiles.Any(t => t.Id == TileId.Ball && t.Y == 20));

            if (tiles.Any(t => t.Id == TileId.Block))
            {
                throw new Exception("Simulation finished before all blocks were destroyed.");
            }

            return score;
        }

        private static (IEnumerable<Tile> Tiles, long? Score) Parse(this IReadOnlyList<long> output)
        {
            var grouped = output.Select((o, i) => (o, i))
                .GroupBy(e => Convert.ToInt32(Math.Floor(e.i / 3.0)));
            var score = grouped.LastOrDefault(g => g.ElementAt(0).o == -1)?.ElementAt(2).o;
            var tiles = grouped.Where(g => g.ElementAt(0).o != -1).Select(g => new Tile(g.ElementAt(0).o, g.ElementAt(1).o, (TileId)g.ElementAt(2).o)).ToArray();
            return (tiles, score);
        }

        private static void UpdateTiles(List<Tile> tiles, IEnumerable<Tile> newTiles)
        {
            if (!tiles.Any())
            {
                tiles.AddRange(newTiles);
                return;
            }

            foreach (var newTile in newTiles)
            {
                var tile = tiles.SingleOrDefault(t => t.X == newTile.X && t.Y == newTile.Y);
                if (tile != null)
                {
                    tile.SetId(newTile.Id);
                }
                else
                {
                    tiles.Add(newTile);
                }
            }
        }

        private static Joystick UseJoystickSimple(IEnumerable<Tile> tiles, IList<PointLong> ballPositions)
        {
            var ball = tiles.Single(t => t.Id == TileId.Ball);
            var paddle = tiles.Single(t => t.Id == TileId.HorizontalPaddle);

            if (!ballPositions.Any())
            {
                ballPositions.Add(ball);
                return (Joystick)(ball.X - paddle.X).Normalize();
            }

            var last = ballPositions.Last();
            ballPositions.Add(ball);
            var directionX = ball.X - last.X;
            var nextX = ball.X + directionX;
            if (directionX < 0 && paddle.X < nextX || directionX > 0 && paddle.X > nextX || ball.Y - last.Y > 0 && paddle.X == ball.X)
            {
                return Joystick.Neutral;
            }
            return (Joystick)directionX.Normalize();
        }

        public static string[] RenderTiles(IEnumerable<Tile> tiles)
        {
            long xMin = tiles.Min(t => t.X),
                 yMin = tiles.Min(t => t.Y),
                 xMax = tiles.Max(t => t.X),
                 yMax = tiles.Max(t => t.Y);
            return tiles.GroupBy(t => t.Y)
                .OrderBy(g => g.Key)
                .Select(g => string.Join("", g.OrderBy(t => t.X).Select(RenderChar)))
                .ToArray();
        }

        private static char RenderChar(Tile tile)
        {
            switch (tile.Id)
            {
                case TileId.Ball:
                    return '•';
                case TileId.Block:
                    return '▒';
                case TileId.Empty:
                    return ' ';
                case TileId.HorizontalPaddle:
                    return '▔';
                case TileId.Wall:
                    return '█';
                default:
                    throw new NotImplementedException($"Tile {tile.Id} was not implemented.");
            }
        }
    }
}
