using Day11Task1Solution.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11Task1Solution.Models
{
    public class Canvas
    {
        private readonly IDictionary<(long X, long Y), Color> _canvas;

        internal Canvas()
        {
            _canvas = new Dictionary<(long, long), Color>();
        }

        internal void PaintPixel(Point pixel, Color color)
        {
            if (!_canvas.ContainsKey((pixel.X, pixel.Y)))
            {
                _canvas.Add((pixel.X, pixel.Y), color);
            }
            else
            {
                _canvas[(pixel.X, pixel.Y)] = color;
            }
        }

        public int GetPixelColor(Point pixel)
        {
            if (!_canvas.TryGetValue((pixel.X, pixel.Y), out Color pixelColor))
            {
                pixelColor = Color.Black;
            }
            return (int)pixelColor;
        }

        public int[][] Render()
        {
            long xMod = -1 * Math.Min(_canvas.Keys.Select(p => p.X).Min(), 0);
            long yMod = -1 * Math.Min(_canvas.Keys.Select(p => p.Y * -1).Min(), 0);

            long width = xMod + _canvas.Keys.Select(p => p.X).Max() + 1;
            long height = yMod + _canvas.Keys.Select(p => p.Y * -1).Max() + 1;

            int[][] paintedCanvas = new int[height][];

            for (var y = 0; y < height; y++)
            {
                int[] row = new int[width];

                for (var x = 0; x < width; x++)
                {
                    if (!_canvas.TryGetValue((x - xMod, -1 * y - yMod), out Color pixelColor))
                    {
                        pixelColor = Color.Black;
                    }
                    row[x] = (int)pixelColor;
                }

                paintedCanvas[y] = row;
            }

            return paintedCanvas;
        }

        public int TotalPainted { get => _canvas.Count; }
    }
}
