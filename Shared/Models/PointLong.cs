namespace Shared.Models
{
    public class PointLong
    {
        public PointLong(long x, long y)
        {
            X = x;
            Y = y;
        }

        public long X { get; protected set; }
        public long Y { get; protected set; }
    }
}
