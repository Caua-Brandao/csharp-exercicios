using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FilesExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = @"C:\Users\cauab\OneDrive\Desktop\data\employees.csv";
                Directory.CreateDirectory(@"C:\Users\cauab\OneDrive\Desktop\data\out");
                string targetPath = @"C:\Users\cauab\OneDrive\Desktop\data\out\payroll.csv";
                List<(string name, string cargo, double salario)> lista = new List<(string name, string cargo, double salario)>();

                using (StreamReader sr = File.OpenText(sourcePath))
                {
                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] lines = line.Split(',');
                            double hora_extra = double.Parse(lines[3], CultureInfo.InvariantCulture);
                            double salario = double.Parse(lines[2], CultureInfo.InvariantCulture);
                            double valor_hora = salario / 220.0;
                            double valor_hora_extra = valor_hora + (valor_hora * 0.5);

                            double total = (salario + (hora_extra * valor_hora_extra));

                            lista.Add((lines[0], lines[1], total));
                        }
                        
                        lista.Sort((a, b) => b.salario.CompareTo(a.salario));

                        foreach(var func in lista)
                        {
                            sw.WriteLine($"{func.name}, {func.cargo}, {func.salario.ToString("F2", CultureInfo.InvariantCulture)}");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
