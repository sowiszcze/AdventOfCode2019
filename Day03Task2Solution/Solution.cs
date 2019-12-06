using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03Task2Solution
{
    public static class Solution
    {
        public static IList<(char, int)> CreateCommandsList(string input)
        {
            return input.Split(',').Select(e => (e[0], int.Parse(e.Substring(1)))).ToList();
        }


    }
}
