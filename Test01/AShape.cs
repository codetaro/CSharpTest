namespace CSharpTest.Test01
{
    public abstract class AShape
    {
        public virtual double Area { get; }
        public virtual Color Color { get; set; }
        public virtual double? Perimeter { get; }

        protected AShape(Color c)
        {
            Color = c;
        }
    }
}