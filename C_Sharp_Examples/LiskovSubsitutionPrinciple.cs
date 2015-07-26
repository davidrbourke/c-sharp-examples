using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class LiskovSubsitutionPrinciple
    {
        public List<Rectangle> ExampleFailsLiskovSubstitutionPrinciple()
        {
            var rect = new Rectangle { Height = 10, Width = 20 };
            var sqr = new Square { Height = 10 };

            var shapes = new List<Rectangle>
            {
                rect, sqr
            };
            return shapes;
        }

        public List<Shape> ExamplePassesLiskovSubstitutionPrinciple()
        {
            var rect = new Rectangle2 { Height = 10, Width = 20 };
            var sqr = new Square2 { Height = 10 };

            var shapes = new List<Shape>
            {
                rect, sqr
            };
            return shapes;
        }
    }

    public class Rectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual int GetArea()
        {
            return Height * Width;
        }
    }

    class Square: Rectangle
    {
        public new int Height { get; set; }

        public override int GetArea()
        {
            return Height * Height;
        }
    }

    public abstract class Shape
    {
         public abstract int GetArea();
    }

    public class Rectangle2 : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override int GetArea()
        {
            return Height * Width;
        }
    }

    public class Square2 : Shape
    {
        public new int Height { get; set; }

        public override int GetArea()
        {
            return Height * Height;
        }
    }
}
