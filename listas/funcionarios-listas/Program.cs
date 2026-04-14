using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcionarios_listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees emp;
            List<Employees> list = new List<Employees>();
            Console.Write("How many employees will be registered: ");
            int n = int.Parse(Console.ReadLine());
            for (int i=0;i<n;i++)
            {
                Console.WriteLine($"Employe {i+1}");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());
                emp = new Employees(id, name, salary);
                list.Add(emp);
            }
            Console.WriteLine("List of employess: ");
            foreach (Employees obj in list)
            {
                Console.WriteLine(obj);
            }
            Console.Write("Enter the ID of the employee whose salary will be increased: ");
            int e = int.Parse(Console.ReadLine());
            Employees pos = list.Find(x => x.Id == e);
            if (pos == null)
            {
                Console.WriteLine("This ID does not exist!");
            }
            else
            {
                Console.Write("Enter to the porcentage: ");
                int porcent = int.Parse(Console.ReadLine());
                pos.IncreaseSalary(porcent);
            }
            Console.WriteLine("Updated list of employees: ");
            foreach (Employees obj in list)
            {
                Console.WriteLine(obj);
            }
        }
    }
    class Employees
    {
        public int Id { get; private set; } 
        public string Name { get; set; } 
        public double Salary { get; set; }

        public Employees(int id, string name, double salary)
        {
            this.Id = id;
            this.Name = name;
            this.Salary = salary;
        }
        public void IncreaseSalary(double porcent)
        {
            Salary = Salary + ((porcent / 100.0) * Salary);
        }
        public override string ToString()
        {
            return "Id: " +
                Id +
                ", Name: " +
                Name +
                ", Salary: " +
                Salary;
        }
    }
}
