using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Data: ");
        string data = Console.ReadLine();

        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        string nomeSemEspaco = nome.Trim();
        string nomeMaiusculo = nomeSemEspaco.ToUpper();
        string abreviado = (nomeMaiusculo.Length >= 3) ? nomeMaiusculo.Substring(0, 3) : nomeMaiusculo;

        DateTime nascimento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Você já fez aniversário este ano? (s/n)");
        string confirmacao = Console.ReadLine().Trim().ToLower();

        int idade = (confirmacao == "n")
            ? DateTime.Now.Year - nascimento.Year - 1
            : DateTime.Now.Year - nascimento.Year;

        double desconto = (preco < 100.0) ? preco * 0.10 : preco * 0.05;
        double precoFinal = preco - desconto;

        Console.WriteLine("1 - Mostrar nome formatado");
        Console.WriteLine("2 - Mostrar dados da data");
        Console.WriteLine("3 - Mostrar preço com desconto");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Console.WriteLine("Nome formatado: " + nomeMaiusculo);
                Console.WriteLine("Abreviado: " + abreviado);
                break;

            case 2:
                Console.WriteLine("Nascimento: " + nascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("Nascimento local: " + nascimento.ToLocalTime());
                Console.WriteLine("Nascimento UTC: " + nascimento.ToUniversalTime());
                Console.WriteLine("Idade: " + idade);
                break;

            case 3:
                Console.WriteLine("Preço original: " + preco.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Desconto: " + desconto.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine("Preço final: " + precoFinal.ToString("F2", CultureInfo.InvariantCulture));
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}