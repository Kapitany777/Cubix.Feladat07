using static System.Math;

namespace F03.Library
{
    public class Vector2D
    {
        public double X { get; }

        public double Y { get; }

        public Vector2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Length => Sqrt(X * X + Y * Y);

        public override string ToString()
        {
            return $"[{this.X}; {this.Y}]";
        }
    }
}