using LibraryExercice.Entites;
using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Cadastrar livros
        library.AddBook("Clean Code", "Robert Martin", "001");
        library.AddBook("1984", "George Orwell", "002");
        library.AddBook("Sapiens", "Yuval Harari", "003");

        // Cadastrar membros
        library.AddMember("João Silva", "M001");
        library.AddMember("Maria Santos", "M002");

        Console.WriteLine("\n=== AVAILABLE BOOKS ===");
        library.ListAvailableBooks();

        // Emprestar
        Console.WriteLine("\n=== LOANS ===");
        library.LoanBook("001", "M001"); // João pega Clean Code
        library.LoanBook("002", "M002"); // Maria pega 1984

        Console.WriteLine("\n=== AVAILABLE BOOKS AFTER LOANS ===");
        library.ListAvailableBooks();

        Console.WriteLine("\n=== ACTIVE LOANS ===");
        library.ListActiveLoans();

        // Devolver
        Console.WriteLine("\n=== RETURNS ===");
        library.ReturnBook("001"); // João devolve Clean Code

        Console.WriteLine("\n=== ACTIVE LOANS AFTER RETURNS ===");
        library.ListActiveLoans();

        Console.WriteLine("\n=== AVAILABLE BOOKS ===");
        library.ListAvailableBooks();
    }
}