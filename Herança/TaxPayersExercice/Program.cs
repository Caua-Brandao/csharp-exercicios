using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TaxPayersExercice.Entities;

namespace TaxPayersExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> payers = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());


            for (int i=1;i<=n;i++)
            {
                Console.WriteLine($"Tax payer {i} data: ");
                Console.Write("Individual or company (i/c): ");
                char ch = char.Parse(Console.ReadLine());
                string name = Console.ReadLine();
                double anualincome = double.Parse(Console.ReadLine());
                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthexpenditures = double.Parse(Console.ReadLine());
                    Individual ind = new Individual(name, anualincome, healthexpenditures);
                    payers.Add(ind);
                }
                else if (ch == 'c')
                {
                    Console.Write("Number of employees: ");
                    int numberofemployees = int.Parse(Console.ReadLine());
                    Company comp = new Company(name, anualincome, numberofemployees);
                    payers.Add(comp);
                }
            }
            double sum = 0;
            foreach (TaxPayer tp in payers)
            {
                Console.WriteLine($"{tp.Name}: $ {tp.Tax()}");
            }
            foreach (TaxPayer tp in payers)
            {
                sum += tp.Tax();
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL TAXES: $ {sum}");
        }
    }
}
