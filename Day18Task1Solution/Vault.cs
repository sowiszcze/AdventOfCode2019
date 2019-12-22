using Day18Task1Solution.Enums;
using Day18Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day18Task1Solution
{
    public class Vault
    {
        private readonly List<Tile> tiles;
        private readonly IReadOnlyCollection<char> keys;
        private readonly long totalKeys;
        private long currentMinimum = long.MaxValue;

        public Vault(string[] rows)
        {
            tiles = new List<Tile>();
            ParseDataRows(rows);
            RemoveDeadEnds();
            keys = tiles.Where(t => t.Content == Content.Key).Select(t => t.Source).Distinct().ToList().AsReadOnly();
            totalKeys = keys.Count();
            PrecalculatePaths();
        }

        public long CalculateMinimumStepsForAllKeys()
        {
            var start = tiles.Single(t => t.Content == Content.Enterance);
            return CalculateMinimumStepsForAllKeys(start);
        }

        public long FindMinimumStepsForAllKeys()
        {
            var start = tiles.Single(t => t.Content == Content.Enterance);
            return FindMinimumStepsForAllKeys(start);
        }

        private void ParseDataRows(string[] rows)
        {
            var temp = new Tile[rows.Length][];
            for (var y = 0; y < rows.Length; y++)
            {
                temp[y] = new Tile[rows[y].Length];
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

                    temp[y][x] = new Tile(x, y, content, point);
                    temp[y][x].AddNeighbour(temp[y - 1][x], true);
                    temp[y][x].AddNeighbour(temp[y][x - 1], true);
                }
            }
            tiles.AddRange(temp.SelectMany(t => t).Where(t => t != null));
        }

        private void PrecalculatePaths()
        {
            foreach (var tile in tiles.Where(t => t.Content == Content.Enterance || t.Content == Content.Key))
            {
                tile.AddPaths(tile.Neighbours.SelectMany(n => FindAllPaths(n, tile, new char[] { }, new char[] { }, 0)));
            }
        }

        private IEnumerable<Path> FindAllPaths(Tile start, Tile source, IEnumerable<char> previousDoors, IEnumerable<char> previousKeys, long steps)
        {
            var doors = new List<char>();
            var paths = new List<Path>();
            var keys = new List<char>();

            Tile current;
            var previous = source;
            IEnumerable<Tile> next = new Tile[] { start };
            doors.AddRange(previousDoors);
            keys.AddRange(previousKeys);

            do
            {
                current = next.First();
                steps++;
                if (current.Content == Content.Door)
                {
                    doors.Add(current.Source);
                }
                else if (current.Content == Content.Key)
                {
                    paths.Add(new Path(doors, keys, steps, current));
                    keys.Add(current.Source);
                }
                next = current.Neighbours.Where(n => n != previous).ToArray();
                previous = current;
            } while (next.Count() == 1);

            if (next.Any())
            {
                return paths.Union(next.SelectMany(n => FindAllPaths(n, current, doors, keys, steps)));
            }

            return paths;
        }

        private IEnumerable<(Tile Destination, long Distance)> FindKeys(Tile start, Tile source, IEnumerable<char> foundKeys)
        {
            var previous = source;
            IEnumerable<Tile> next = new Tile[] { start };
            Tile current;
            long steps = 0;

            do
            {
                current = next.First();
                steps++;
                if (current.Content == Content.Door && !foundKeys.Contains(char.ToLower(current.Source)))
                {
                    return Array.Empty<(Tile, long)>();
                }
                else if (current.Content == Content.Key && !foundKeys.Contains(current.Source))
                {
                    return new (Tile, long)[] { (current, steps) };
                }
                next = current.Neighbours.Where(n => n != previous).ToArray();
                previous = current;
            } while (next.Count() == 1);

            if (next.Any())
            {
                return next.Select(n => FindKeys(n, current, foundKeys)).SelectMany(e => e).Select(e => (e.Destination, e.Distance + steps));
            }

            return Array.Empty<(Tile, long)>();
        }

        private long CalculateMinimumStepsForAllKeys(Tile from)
        {
            return CalculateMinimumStepsForAllKeys(from, new char[] { }, 0);
        }

        private long CalculateMinimumStepsForAllKeys(Tile from, IEnumerable<char> foundKeys, long distance)
        {
            if (foundKeys.Distinct().Count() == totalKeys)
            {
                return distance;
            }

            return from.Neighbours
                .Select(n => FindKeys(n, from, foundKeys))
                .SelectMany(k => k)
                .Select(k => CalculateMinimumStepsForAllKeys(k.Destination, new char[] { k.Destination.Source }.Union(foundKeys), distance + k.Distance))
                .Min();
        }

        private long FindMinimumStepsForAllKeys(Tile from)
        {
            return FindMinimumStepsForAllKeys(from, new char[] { }, 0).Value;
        }

        private long? FindMinimumStepsForAllKeys(Tile from, IEnumerable<char> foundKeys, long distance)
        {
            Debug.WriteLine($"Point: {from.Source} | Distance: {distance} | Keys: {new string(foundKeys.ToArray())}");
            if (foundKeys.Distinct().Count() == totalKeys)
            {
                currentMinimum = Math.Min(currentMinimum, distance);
                return distance;
            }

            var toConsider = from.Paths.Where(p => p.IsAvailable(foundKeys) && !foundKeys.Contains(p.Key)).ToArray();
            toConsider = toConsider.Where(p => !toConsider.Any(o => o.KeysExclusive.Contains(p.Key))).Where(p => p.Distance + distance < currentMinimum).OrderBy(p => p.Keys.Count()).ToArray();

            return toConsider.Length > 0 ? toConsider.Select(p => FindMinimumStepsForAllKeys(p.Destination, p.Keys.Union(foundKeys), distance + p.Distance)).Min() : null;
        }

        private void RemoveDeadEnds()
        {
            IEnumerable<Tile> toRemove;
            do
            {
                toRemove = tiles.Where(t => t.Content == Content.None && t.Neighbours.Count == 1).ToArray();
                foreach (var tile in toRemove)
                {
                    tiles.Remove(tile);
                    tile.Neighbours.ToList().ForEach(t => t.RemoveNeighbour(tile));
                }
            } while (toRemove.Count() > 0);
        }
    }
}
