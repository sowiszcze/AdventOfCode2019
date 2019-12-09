using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day08Task1Solution
{
    public class Solution
    {
        public static IEnumerable<string> RenderImage(int[][] image)
        {
            foreach (var row in image)
            {
                var builder = new StringBuilder();
                foreach (var pixel in row)
                {
                    switch (pixel)
                    {
                        case 0:
                            builder.Append("█");
                            break;
                        case 1:
                            builder.Append("░");
                            break;
                        default:
                            throw new NotImplementedException($"Color {pixel} is not implemented.");
                    }
                }
                yield return builder.ToString();
            }
        }

        public static int[][] FlattenImage(int[][][] image)
        {
            var layers = image.Length;
            var height = image[0].Length;
            var width = image[0][0].Length;
            var flattened = new int[height][];

            for (var r = 0; r < height; r++)
            {
                var row = new int[width];

                for (var c = 0; c < width; c++)
                {
                    for (var l = 0; l < layers; l ++)
                    {
                        if (image[l][r][c] != 2)
                        {
                            row[c] = image[l][r][c];
                            break;
                        }
                    }
                }

                flattened[r] = row;
            }
            return flattened;
        }

        public static int[][][] CreateImage(string input, int width, int height)
        {
            var data = input.Select(c => int.Parse(c.ToString()));
            var layers = data.Count() / (width * height);
            var image = new int[layers][][];

            for (var l = 0; l < layers; l++)
            {
                var layer = new int[height][];
                for (var r = 0; r < height; r++)
                {
                    layer[r] = data.Skip(l * width * height + r * width).Take(width).ToArray();
                }
                image[l] = layer;
            }

            return image;
        }

        public static int CountDigits(int[][] layer, int digit)
        {
            return layer.Sum(x => x.Count(y => y == digit));
        }

        public static int GetResult(string input, int width, int height, int condition, int first, int second)
        {
            var image = CreateImage(input, width, height);
            int currentMin = int.MaxValue;
            int selectedLayer = -1;
            for (var i = 0; i < image.Length; i++)
            {
                var count = CountDigits(image[i], condition);
                if (count < currentMin)
                {
                    currentMin = count;
                    selectedLayer = i;
                }
            }
            return CountDigits(image[selectedLayer], first) * CountDigits(image[selectedLayer], second);
        }
    }
}
