namespace CSharpTest.Test01
{
    public class Triangle : AShape
    {
        private int _base;
        private int _height;

        public Triangle(int b, int h, Color c) : base(c)
        {
            _base = b;
            _height = h;
        }

        public override double Area
        {
            get { return _base * _height * 0.5; }
        }

        public override double? Perimeter
        {
            get { return null; }
        }
    }
}