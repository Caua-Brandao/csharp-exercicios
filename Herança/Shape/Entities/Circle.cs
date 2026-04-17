using System;


namespace ShapeExercice.Entities
{
    internal class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle()
        {
        }
        public Circle(double radius, Color color) : base(color)
        {
            this.Radius = radius;
        }

        public override double Area()
        {
            double area = Math.PI * (Radius * Radius);
            return Math.Round(area, 2);
        }
    }
}
