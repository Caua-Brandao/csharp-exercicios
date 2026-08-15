using LinqExercice2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\cauab\OneDrive\Desktop\Employees.csv";
            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader sr = new StreamReader(sourcePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');
                        string name = data[0];
                        string email = data[1];
                        double salary = double.Parse(data[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }
                Console.Write("Enter salary: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                var emails = employees.Where(e => e.Salary > value).OrderBy(e => e.Email).Select(e => e.Email);
                Console.WriteLine("EMAIL OF PEOPLE WHOSE SALARY IS MORE THAN " + value.ToString("F2", CultureInfo.InvariantCulture));
                foreach(var email in emails)
                {
                    Console.WriteLine(email);
                }
                var sum = employees.Where(p => p.Name.StartsWith("M")).Sum(p => p.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(DirectoryNotFoundException d)
            {
                Console.WriteLine("An error occurred: " + d.Message);
            }
        }
    }
}
