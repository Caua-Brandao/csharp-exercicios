using System;


namespace ShapeExercice.Entities
{
    internal class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle()
        {
        }
        public Rectangle(double width, double height, Color color):base(color)
        {
            this.Width = width;
            this.Height = height;        }

        public override double Area()
        {
            double area = Width * Height;
            return Math.Round(area, 2);
        }
    }

}
