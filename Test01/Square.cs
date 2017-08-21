namespace CSharpTest.Test01
{
    public class Square : AShape
    {
        private int _side;

        public Square(int s, Color c) : base(c)
        {
            _side = s;
        }

        public override double Area
        {
            get { return _side * _side; }
        }

        public override double? Perimeter
        {
            get { return _side * 4; }
        }
    }
}