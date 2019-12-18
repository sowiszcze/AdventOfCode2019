using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18Task1Solution.Models
{
    public class Path
    {
        public Path(IEnumerable<char> doors, IEnumerable<char> keys, long distance, Tile destination)
        {
            Distance = distance;
            Destination = destination;
            Doors = doors.Select(d => char.ToLower(d)).ToList().AsReadOnly();
            KeysExclusive = keys.Distinct().ToList().AsReadOnly();
            Keys = new char[] { Destination.Source }.Union(keys).Distinct().ToList().AsReadOnly();
        }

        public Tile Destination { get; private set; }
        public long Distance { get; private set; }

        public IReadOnlyCollection<char> KeysExclusive { get; private set; }
        public IReadOnlyCollection<char> Keys { get; private set; }
        public IReadOnlyCollection<char> Doors { get; private set; }

        public char Key => Destination.Source;

        public bool IsAvailable(IEnumerable<char> keys)
        {
            return Doors.All(d => keys.Contains(d));
        }
    }
}
