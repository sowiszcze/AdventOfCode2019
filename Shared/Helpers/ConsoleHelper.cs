using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Helpers
{
    public static class ConsoleHelper
    {
        public static IEnumerable<string> Render<T>(T[][] image, Dictionary<T, string> mapping)
        {
            foreach (var row in image)
            {
                var builder = new StringBuilder();
                foreach (var pixel in row)
                {
                    if (mapping.TryGetValue(pixel, out string character))
                    {
                        builder.Append(character);
                    }
                    else
                    {
                        builder.Append(pixel);
                    }
                }
                yield return builder.ToString();
            }
        }

        public static void PrintResult<T>(T result)
        {
            Console.WriteLine($"The result is: {result}");
        }

        public static void PrintResult(IEnumerable<string> result)
        {
            Console.WriteLine($"The result is:");
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}
