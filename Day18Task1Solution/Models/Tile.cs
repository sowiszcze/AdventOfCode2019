﻿using Day18Task1Solution.Enums;
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
        private readonly List<Path> paths;

        public Tile(long x, long y, Content content, char source)
            : base(x, y)
        {
            Source = source;
            Content = content;
            neighbours = new List<Tile>();
            paths = new List<Path>();
        }

        public char Source { get; private set; }
        public Content Content { get; private set; }

        public IReadOnlyList<Tile> Neighbours => neighbours.AsReadOnly();
        public IReadOnlyList<Path> Paths => paths.AsReadOnly();

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

        public void RemoveNeighbour(Tile neighbour)
        {
            if (neighbour == null)
            {
                return;
            }

            neighbours.Remove(neighbour);
        }

        public void AddPath(Path path)
        {
            paths.Add(path);
        }

        public void AddPaths(IEnumerable<Path> paths)
        {
            this.paths.AddRange(paths);
        }
    }
}
