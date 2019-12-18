using Day18Task1Solution.Enums;
using Day18Task1Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18Task1Solution
{
    public class Vault
    {
        private readonly List<Tile> tiles;

        public Vault(string[] rows)
        {
            tiles = new List<Tile>();
            ParseDataRows(rows);
        }

        public long CalculateMinimumStepsForAllKeys()
        {
            throw new NotImplementedException();
        }

        private void ParseDataRows(string[] rows)
        {
            for (var y = 0; y < rows.Length; y++)
            {
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

                    var tile = new Tile(x, y, content, point);
                    tile.AddNeighbours(tiles.Where(t => t.X == x - 1 && t.Y == y || t.X == x && t.Y == y - 1), true);
                    tiles.Add(tile);
                }
            }
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
                next = current.Neighbours.Where(n => n != previous);
                previous = current;
            } while (next.Count() == 1);

            if (next.Any())
            {
                return next.Select(n => FindKeys(n, current, foundKeys)).SelectMany(e => e).Select(e => (e.Destination, e.Distance + steps));
            }

            return Array.Empty<(Tile, long)>();
        }
    }
}
