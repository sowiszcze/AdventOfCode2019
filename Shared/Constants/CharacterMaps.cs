using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Constants
{
    public static class CharacterMaps
    {
        public static Dictionary<int, string> Bit => new Dictionary<int, string> { { 0, "░" }, { 1, "█" } };
        public static Dictionary<int, string> BitInverted => new Dictionary<int, string> { { 0, "█" }, { 1, "░" } };
    }
}
