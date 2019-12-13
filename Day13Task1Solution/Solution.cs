using Day13Task1Solution.Enums;
using Day13Task1Solution.Models;
using IntcodeInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
