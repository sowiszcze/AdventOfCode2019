using Day18Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day18Task1Solution.Models
{
    public class Tile : PointLong
    {
        private readonly List<Tile> neighbours;

        public Tile(long x, long y, Content content, char source)
            : base(x, y)
        {
            Source = source;
            Content = content;
            neighbours = new List<Tile>();
        }

        public char Source { get; private set; }
        public Content Content { get; private set; }

        public IReadOnlyList<Tile> Neighbours => neighbours.AsReadOnly();

        public void AddNeighbour(Tile neighbour, bool propagate)
        {
            if (neighbour == null)
            {
                return;
            }

            neighbours.Add(neighbour);
            if (propagate)
            {
                neighbour.AddNeighbour(this, false);
            }
        }
        public void AddNeighbours(IEnumerable<Tile> neighbours, bool propagate)
        {
            if (neighbours == null || !neighbours.Any())
            {
                return;
            }

            this.neighbours.AddRange(neighbours);
            if (propagate)
            {
                foreach (var neighbour in neighbours)
                {
                    neighbour.AddNeighbour(this, false);
                }
            }
        }
    }
}
