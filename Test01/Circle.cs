using System;

namespace CSharpTest.Test01
{
    public class Circle : AShape
    {
        private int _radius;

        public Circle(int r, Color c) : base(c)
        {
            _radius = r;
        }

        public override double Area
        {
            get { return Math.PI * _radius * _radius; }
        }

        public override double? Perimeter
        {
            get { return Math.PI * _radius * 2; }
        }
    }
}