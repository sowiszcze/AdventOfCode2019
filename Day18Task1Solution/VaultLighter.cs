using Day18Task1Solution.Enums;
using Day18Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Task1Solution
{
    public class VaultLighter
    {
        private readonly List<TileLighter> tiles;
        private readonly Lock keys;
        private long currentMinimum = long.MaxValue;

        public VaultLighter(string[] rows)
        {
            tiles = new List<TileLighter>();
            ParseDataRows(rows);
            RemoveDeadEnds();
            keys = tiles.Where(t => t.Content == Content.Key).Aggregate(Lock.None, (x, tile) => x | tile.Lock);
            PrecalculatePaths();
        }

        private void ParseDataRows(string[] rows)
        {
            var temp = new TileLighter[rows.Length][];
            for (var y = 0; y < rows.Length; y++)
            {
                temp[y] = new TileLighter[rows[y].Length];
                for (var x = 0; x < rows[y].Length; x++)
                {
                    char point = rows[y][x];
                    var content = Content.None;

                    if (point == '@') // ENTERANCE
                    {
                        content = Content.Enterance;
                    }
                    else if (point >= 'a' && point <= 'z') // KEY
                    {
                        content = Content.Key;
                    }
                    else if (point >= 'A' && point <= 'Z') // DOOR
                    {
                        content = Content.Door;
                    }
                    else if (point == '#') // WALL
                    {
                        continue;
                    }
                    else if (point != '.') // NOT PASSAGE
                    {
                        throw new NotImplementedException($"Tile type {point} not implemented at X={x};Y={y}");
                    }

                    temp[y][x] = new TileLighter(x, y, content, point);
                    temp[y][x].AddNeighbour(temp[y - 1][x], true);
                    temp[y][x].AddNeighbour(temp[y][x - 1], true);
                }
            }
            tiles.AddRange(temp.SelectMany(t => t).Where(t => t != null));
        }

        private void RemoveDeadEnds()
        {
            IEnumerable<TileLighter> toRemove;
            do
            {
                toRemove = tiles.Where(t => (t.Content == Content.None || t.Content == Content.Door) && t.Neighbours.Count == 1).ToArray();
                foreach (var tile in toRemove)
                {
                    tiles.Remove(tile);
                    tile.Neighbours.ToList().ForEach(t => t.RemoveNeighbour(tile));
                }
            } while (toRemove.Count() > 0);
        }

        private void PrecalculatePaths()
        {
            Parallel.ForEach(tiles.Where(t => t.Content == Content.Enterance || t.Content == Content.Key), tile =>
            {
                var paths = tile.Neighbours.SelectMany(n => FindAllPaths(n, tile));
                paths = paths.GroupBy(p => p.Key).Select(g => g.OrderBy(p => p.Distance).First());
                tile.AddPaths(paths);
            });
        }

        private IEnumerable<PathLighter> FindAllPaths(TileLighter start, TileLighter source)
        {
            var toProcess = new List<(IEnumerable<TileLighter> Previous, TileLighter Current, Lock Keys, Lock Doors)> { (new TileLighter[] { source }, start, Lock.None, Lock.None) };

            for (var steps = 1; toProcess.Any(); steps++)
            {
                var next = new List<(IEnumerable<TileLighter> Previous, TileLighter Current, Lock Keys, Lock Doors)>();
                foreach (var (previous, current, currentKeys, currentDoors) in toProcess)
                {
                    Lock keys = currentKeys;
                    Lock doors = currentDoors;
                    if (current.Content == Content.Key)
                    {
                        yield return new PathLighter(doors, keys, steps, current);
                        keys |= current.Lock;
                    }
                    else if (current.Content == Content.Door)
                    {
                        doors |= current.Lock;
                    }
                    next.AddRange(current.Neighbours.Where(n => !previous.Contains(n)).Select(n => (previous.Union(new TileLighter[] { current }), n, keys, doors)));
                }
                toProcess = next;
            }
        }

        public long FindMinimumStepsForAllKeys()
        {
            var start = tiles.Single(t => t.Content == Content.Enterance);
            return FindMinimumStepsForAllKeys(start);
        }

        private long FindMinimumStepsForAllKeys(TileLighter from)
        {
            return FindMinimumStepsForAllKeys(from, Lock.None, 0).Value;
        }

        private long? FindMinimumStepsForAllKeys(TileLighter from, Lock foundKeys, long distance)
        {
            if ((foundKeys & keys) == keys)
            {
                currentMinimum = Math.Min(currentMinimum, distance);
                return distance;
            }

            var toConsider = from.Paths.Where(p => p.IsAvailable(foundKeys) && !foundKeys.HasFlag(p.Key)).ToArray();
            toConsider = toConsider.Where(p => !toConsider.Any(o => o.KeysExclusive.HasFlag(p.Key))).Where(p => p.Distance + distance < currentMinimum).OrderBy(p => p.KeysCount).ToArray();

            return toConsider.Length > 0 ? toConsider.Select(p => FindMinimumStepsForAllKeys(p.Destination, p.Keys | foundKeys, distance + p.Distance)).Where(p => p.HasValue).Min() : null;
        }

        public IEnumerable<string> Render()
        {
            for (var y = 0; y <= tiles.Max(t => t.Y) + 1; y++)
            {
                var builder = new StringBuilder();
                for (var x = 0; x <= tiles.Max(t => t.X) + 1; x++)
                {
                    var toAppend = '█';
                    var tile = tiles.SingleOrDefault(t => t.X == x && t.Y == y);
                    if (tile != null)
                    {
                        switch (tile.Content)
                        {
                            case Content.None:
                                toAppend = ' ';
                                break;
                            case Content.Enterance:
                                toAppend = '@';
                                break;
                            case Content.Door:
                                toAppend = tile.Lock.ToString()[0];
                                break;
                            case Content.Key:
                                toAppend = char.ToLower(tile.Lock.ToString()[0]);
                                break;
                            default:
                                throw new NotImplementedException($"Content type {tile.Content} not implemented, but encountered at X={x};Y={y}.");
                        }
                    }
                    builder.Append(toAppend);
                }
                yield return builder.ToString();
            }
        }
    }
}
