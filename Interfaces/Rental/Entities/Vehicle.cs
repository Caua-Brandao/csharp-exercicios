namespace Rental.Entities
{
    internal class Vehicle
    {
        public string CarModel { get; set; }
        
        public Vehicle(string model)
        {
            CarModel = model;
        }
    }
}
