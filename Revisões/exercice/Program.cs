using exercice.Entities;
using System;
using System.Globalization;

namespace exercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CADASTROS DE LIVROS ===");
            Console.WriteLine();
            Book[] books = new Book[3];

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Livro #{i}: ");
                Console.Write("Título: ");
                string title = Console.ReadLine();
                Console.Write("Author: ");
                string author = Console.ReadLine();
                Console.Write("Ano: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Categoria: (Fiction/NonFiction/Science/Technology/Biography): ");
                BookCategory bookcategory;
                while (!Enum.TryParse<BookCategory>(Console.ReadLine(), true, out bookcategory))
                {
                    Console.WriteLine("Invalid category. Please enter one of: Fiction, NonFiction, Science, Technology, Biography");
                    Console.Write("Categoria: ");
                }
                books[i - 1] = new Book(title, author, year, price, bookcategory);
            }
            Console.WriteLine("=== LIVROS CADASTRADOS ===");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(books[i - 1]);
                Console.WriteLine();
            }
            double sum = 0;
            foreach (Book book in books) 
            {
                sum += book.GetFinalPrice();
            }
            Console.WriteLine("Preço médio final: " + sum.ToString("F2"));

            int fictionCount = 0;
            int nonFictionCount = 0;
            int scienceCount = 0;
            int technologyCount = 0;
            int biographyCount = 0;

            foreach (Book book in books)
            {
                switch (book.Category)
                {
                    case BookCategory.Fiction:
                        fictionCount++;
                        break;
                    case BookCategory.NonFiction:
                        nonFictionCount++;
                        break;
                    case BookCategory.Science:
                        scienceCount++;
                        break;
                    case BookCategory.Technology:
                        technologyCount++;
                        break;
                    case BookCategory.Biography:
                        biographyCount++;
                        break;
                }
            }

            Console.WriteLine("=== LIVROS POR CATEGORIA ===");
            Console.WriteLine($"Fiction: {fictionCount}");
            Console.WriteLine($"NonFiction: {nonFictionCount}");
            Console.WriteLine($"Science: {scienceCount}");
            Console.WriteLine($"Technology: {technologyCount}");
            Console.WriteLine($"Biography: {biographyCount}");

        }
    }
}
