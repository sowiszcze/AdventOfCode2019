using Day18Task1Solution.Enums;

namespace Day18Task1Solution.Models
{
    public class PathLighter
    {
        public PathLighter(Lock doors, Lock keys, int distance, TileLighter destination)
        {
            Distance = distance;
            Destination = destination;
            Doors = doors;
            KeysExclusive = keys;
            Keys = keys | destination.Lock;
            KeysCount = NumberOfSetBits((int)Keys);
        }

        public TileLighter Destination { get; private set; }
        public int Distance { get; private set; }
        public int KeysCount { get; private set; }
        public Lock KeysExclusive { get; private set; }
        public Lock Keys { get; private set; }
        public Lock Doors { get; private set; }

        public Lock Key => Destination.Lock;

        public bool IsAvailable(Lock keys)
        {
            return (Doors & keys) == Doors;
        }

        private int NumberOfSetBits(int i)
        {
            i -= ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }
    }
}
