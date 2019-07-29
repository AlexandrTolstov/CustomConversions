using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun with Conversion ******\n");
            Rectangle r = new Rectangle(15, 4);
            Console.WriteLine(r.ToString());
            r.Draw();

            Console.WriteLine();
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.ReadLine();

            Square sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);
            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);

            Square s3 = new Square { Lenght = 7 };
            Rectangle rect2 = s3;
            Console.WriteLine("rect2 = {0}", rect2);

            Square s4 = new Square { Lenght = 3 };
            Rectangle rect3 = (Rectangle)s4;
            Console.WriteLine("rect3 = {0}", rect3);
        }
    }
    public struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int w, int h) : this()
        {
            Width = w;
            Height = h;
        }
        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"[Width = {Width}; Height = {Height}]";
        }
    }
    public struct Square
    {
        public int Lenght { get; set; }
        public Square(int l) : this()
        {
            Lenght = l;
        }
        public void Draw()
        {
            for (int i = 0; i < Lenght; i++)
            {
                for (int j = 0; j < Lenght; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"[Length = {Lenght}]";
        }
        public static explicit operator Square(Rectangle r)
        {
            Square s = new Square { Lenght = r.Height };
            return s;
        }
        public static explicit operator Square(int sideLenght)
        {
            Square newSq = new Square { Lenght = sideLenght };
            return newSq;
        }
        public static explicit operator int(Square s) => s.Lenght;
        public static implicit operator Rectangle(Square s)
        {
            Rectangle r = new Rectangle
            {
                Height = s.Lenght,
                Width = s.Lenght * 2
            };
            return r;
        }

    }
}
