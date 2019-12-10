namespace Day10Task1Solution.Models
{
    public class Observatory
    {
        public Observatory(Asteroid asteroid, int inView)
        {
            Asteroid = asteroid;
            InView = inView;
        }

        public Asteroid Asteroid { get; private set; }
        public int InView { get; private set; }
    }
}
