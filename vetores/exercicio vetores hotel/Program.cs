using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testes.encapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos quartos serão alugados: ");
            int n = int.Parse(Console.ReadLine());
            Estudante[] vect = new Estudante[10];
            for (int i=0;i<n;i++)
            {
                Console.WriteLine("Aluguel " + (i + 1));
                Console.Write("Nome: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Quarto: ");
                int quarto = int.Parse(Console.ReadLine());
                vect[quarto] = new Estudante { Nome = name, Email = email, Quarto = quarto};
            }
            for (int i=0;i<vect.Length;i++)
            {
                if (vect[i] != null)
                {
                    Console.WriteLine(vect[i]);
                }
            }
        }
    }
    class Estudante
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Quarto { get; set; }
        public override string ToString()
        {
            return Quarto +
                ": " +
                Nome +
                ", " +
                Email;
        }
    }
}
