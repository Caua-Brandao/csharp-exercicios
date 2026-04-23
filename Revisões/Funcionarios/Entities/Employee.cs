
namespace Funcionarios.Entities
{
    abstract class Employee
    {
        public string Name { get; set; }
        public Department Department { get; set; }

        public Employee()
        {
        }
        public Employee(string name, Department department)
        {
            this.Name = name;
            this.Department = department;
        }
        public abstract double CalculatePayment();
        public virtual string GetInfo()
        {
            return $"{Name} - {Department} - Payment: {CalculatePayment()}";
        }
    }
}
