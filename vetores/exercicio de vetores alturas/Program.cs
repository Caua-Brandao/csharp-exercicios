using System;
using System.Globalization;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Número de pessoas: ");
        int n = int.Parse(Console.ReadLine());

        Pessoa[] vect = new Pessoa[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Altura: ");
            double altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            vect[i] = new Pessoa(nome, altura);
        }
        double soma = 0;
        for (int i = 0; i < n; i++)
        {
            soma += vect[i].Altura;
        }
        double media = soma / n;
        Console.WriteLine("\nMédia: " + media.ToString("F2", CultureInfo.InvariantCulture));
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (vect[i].Altura < media)
            {
                count++;
            }
        }
        Console.WriteLine("Pessoas abaixo da média: " + count);

        Console.WriteLine("\nNomes:");
        for (int i = 0; i < n; i++)
        {
            if (vect[i].Altura < media)
            {
                Console.WriteLine(vect[i].Nome);
            }
        }
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public double Altura { get; set; }

    public Pessoa(string nome, double altura)
    {
        Nome = nome;
        Altura = altura;
    }
}