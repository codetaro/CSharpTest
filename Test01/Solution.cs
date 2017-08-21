using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTest.Test01
{
    public static class Solution
    {
        public static void Run()
        {
            var circles = new List<Circle>();
            var squares = new List<Square>();
            var triangles = new List<Triangle>();

            circles.Add(new Circle(10, Color.red));
            circles.Add(new Circle(2, Color.blue));
            circles.Add(new Circle(3, Color.green));

            squares.Add(new Square(10, Color.red));
            squares.Add(new Square(2, Color.blue));
            squares.Add(new Square(3, Color.green));

            triangles.Add(new Triangle(10, 10, Color.red));
            triangles.Add(new Triangle(2, 2, Color.blue));
            triangles.Add(new Triangle(3, 3, Color.green));

            Console.WriteLine("----Question 10----");
            Console.WriteLine("total area of circles: {0}", GetTotalArea(circles));
            Console.WriteLine("total area of squares: {0}", GetTotalArea(squares));
            Console.WriteLine("total area of triangles: {0}", GetTotalArea(triangles));


            Console.WriteLine("----Question 11----");
            Console.WriteLine("sum circles which are red and area size > 10: {0} ",
                GetConditionalArea(circles, c => c.Color == Color.red && c.Area > 10));
            Console.WriteLine("sum squares which are red and area size > 10: {0}",    // Question 11 evolve 1
                Sum(squares, s => s.Area + s.Perimeter, s => s.Color == Color.red && s.Area > 10));
            Console.WriteLine("sum triangles which are red and area size > 10: {0}",  // Question 11 evolve 2
                triangles.SumG(t => t.Area + t.Perimeter, t => t.Color == Color.red && t.Area > 10));
            Console.WriteLine("sum triangles which are red and area size > 10: {0}",  // Using LINQ - equivalent to Q11e2
                triangles.Where(t => t.Color == Color.red && t.Area > 10).Sum(t => t.Area + t.Perimeter));
        }

        // Question 10
        public static double GetTotalArea<T>(List<T> shapes) where T : AShape
        {
            double sum = 0;
            foreach (var shape in shapes)
            {
                sum += shape.Area;
            }
            return sum;
        }

        // Question 11
        public static double GetConditionalArea<T>(List<T> shapes, Func<T, bool> condition) where T : AShape
        {
            double sum = 0;
            foreach (var shape in shapes)
            {
                if (condition(shape))
                {
                    sum += shape.Area;
                }
            }
            return sum;
        }

        // Question 11 evolve 1 - sum the shapes' fields which meat certain conditions
        public static double? Sum<T>(List<T> shapes, Func<T, double?> field, Func<T, bool> condition)
        {
            double? sum = 0;
            foreach (var shape in shapes)
            {
                if (condition(shape))
                {
                    sum += field(shape);
                }
            }
            return sum;
        }

        // Question 11 evolve 2 - extending List<T> with SumG() methods
        public static double? SumG<T>(this List<T> shapes, Func<T, double?> field, Func<T, bool> condition)
        {
            double? sum = 0;
            foreach (var shape in shapes)
            {
                if (condition(shape))
                {
                    sum += field(shape);
                }
            }
            return sum;
        }
    }
}