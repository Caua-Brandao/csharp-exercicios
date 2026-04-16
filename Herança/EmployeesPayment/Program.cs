using System;
using System.Collections.Generic;
using System.Globalization;
using EmployeesPayment.Entities;

namespace EmployeesPayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>();
            Console.WriteLine("Enter the number of employees: ");
            int employees = int.Parse(Console.ReadLine());
            for (int i=1;i<=employees;i++)
            {
                Console.WriteLine($"Employee number {i} data: ");
                Console.Write("Outsourced (y/n): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'y')
                {
                    Console.Write("Adicional charge: ");
                    double adicionalcharge = double.Parse(Console.ReadLine());
                    emp.Add(new OutsourcedEmployee(nome, hours, valueperhour, adicionalcharge));
                }
                else
                {
                    emp.Add(new Employee(nome, hours, valueperhour));
                }
            }
            Console.WriteLine("Payments: ");
            foreach (Employee empl in emp)
            {
                Console.WriteLine($"{empl.Name} - $ {empl.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
