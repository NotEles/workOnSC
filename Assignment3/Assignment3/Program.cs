using System;
using System.Security.Principal;
namespace Pro
{
    class Pro
    {
        interface IsValid
        {
            public bool valid();
        }
        abstract class Shape:IsValid
        {
            public abstract double getArea();
            public bool valid() { return true; }
        }
        class Triangle : Shape
        {
            private int[] side;
            public Triangle(int a,int b,int c)
            {
                side = new int[] { a, b, c };
            }

            public override double getArea()
            {
                double p = (side[0] + side[1] + side[2]) / 2.0;
                return Math.Sqrt(p * (p - side[0]) * (p - side[1]) * (p - side[2]));
            }
            public bool valid()
            {
                return (side[0] > 0) & (side[1] > 0) & (side[2] > 0) & (side[0] + side[1] > side[2]) & (side[1] + side[2] > side[0]) & (side[0] + side[2] > side[1]);
            }
        }

        class Rectangle:Shape
        {
            private int length, width;
            public Rectangle(int len,int wid)
            {
                this.length = len;
                this.width = wid;
            }

            public override double getArea()
            {
                return length * width;
            }
            public bool valid()
            {
                return (length > 0) & (width > 0);
            }
        }
        class Square:Rectangle
        {
            
            public Square(int si):base(si, si) { }
        }
        class Factory
        {
            public Shape CreateShape(int sel, int[] sides) 
            {
                switch (sel)
                {
                    case 1:
                        Triangle tri = new Triangle(sides[0], sides[1], sides[2]);
                        return tri;
                        
                    case 2:
                        Rectangle rec = new Rectangle(sides[0], sides[1]);
                        return rec;
                        
                    case 3:
                        Square squ = new Square(sides[0]);
                        return squ;
                    default:
                        return null;
                }
                
            }
        }
        static void Main()
        {
            Shape[] shapes = new Shape[10];
            Factory fac = new Factory();
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("create a shape in 1 for tri,2 for rec,3 for squ:");
                int sel = int.Parse(Console.ReadLine());
                Console.WriteLine("about the sides:");
                int[] sides = new int[] {0,0,0 };
                for(int j =0; j<3; j++)
                {
                    sides[j] = int.Parse(Console.ReadLine());
                }
                
                shapes[i]=fac.CreateShape(sel, sides);
                if (shapes[i].valid())
                {
                    sum += shapes[i].getArea();
                }

            }
            Console.WriteLine($"{sum}");
        }
    }
}