using System;
using System.Collections.Generic;
using ShapeExercice.Entities;


namespace ShapeExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());
            for (int i =1;i<=n;i++)
            {
                Console.WriteLine($"Shape {i} data: ");
                Console.Write("Rectangle or Circle (r/c): ");
                char resp = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red): ");
                string colorInput = Console.ReadLine();
                Color color;
                if (Enum.TryParse(colorInput, true, out color)) {}
                else
                {
                    Console.WriteLine("Cor inválida!");
                }
                if (resp == 'r')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine());
                    shapes.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine());
                    shapes.Add(new Circle(radius, color));
                }
            }
            Console.WriteLine("SHAPE AREAS");
            foreach (Shape sh in shapes)
            {
                Console.WriteLine(sh.Color);
                Console.WriteLine(sh.Area());
                Console.WriteLine();
            }
        }
    }
}
