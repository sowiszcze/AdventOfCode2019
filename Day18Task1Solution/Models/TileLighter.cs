using Day18Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day18Task1Solution.Models
{
    public class TileLighter : Point
    {
        private readonly List<TileLighter> neighbours;
        private readonly List<PathLighter> paths;

        public TileLighter(int x, int y, Content content, char source)
            : base(x, y)
        {
            Lock = source.ToLock();
            Content = content;
            neighbours = new List<TileLighter>();
            paths = new List<PathLighter>();
        }

        public Lock Lock { get; private set; }
        public Content Content { get; private set; }

        public IReadOnlyList<TileLighter> Neighbours => neighbours.AsReadOnly();
        public IReadOnlyList<PathLighter> Paths => paths.AsReadOnly();

        public void AddNeighbour(TileLighter neighbour, bool propagate)
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

        public void AddNeighbours(IEnumerable<TileLighter> neighbours, bool propagate)
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

        public void RemoveNeighbour(TileLighter neighbour)
        {
            if (neighbour == null)
            {
                return;
            }

            neighbours.Remove(neighbour);
        }

        public void AddPath(PathLighter path)
        {
            paths.Add(path);
        }

        public void AddPaths(IEnumerable<PathLighter> paths)
        {
            this.paths.AddRange(paths);
        }
    }
}
