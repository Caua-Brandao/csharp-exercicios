using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExercice.Entites
{
    internal class Library
    {
        public List<Book> books { get; set; }
        public List<Member> members { get; set; }
        public List<Loan> loans { get; set; }

        public Library()
        {
            books = new List<Book>();
            members = new List<Member>();
            loans = new List<Loan>();
        }

        public void AddBook(string title, string author, string isbn)
        {
            Book book = new Book(title, author, isbn);
            books.Add(book);
            Console.WriteLine($"Book {title} added succesfully");
        }

        public void AddMember(string name, string memberid)
        {
            Member member = new Member(name, memberid);
            members.Add(member);
            Console.WriteLine($"Member {name} added succesfully");
        }

        public void LoanBook(string isbn, string memberId)
        {
            Book book = books.Find(b => b.Isbn == isbn);
            Member member = members.Find(m => m.MemberId == memberId);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Book unavailable!");
                return;
            }

            Loan loan = new Loan(book, member);
            loans.Add(loan);
            Console.WriteLine($"Book '{book.Title}' lent to {member.Name}");
        }
        public void ReturnBook(string isbn)
        {
            Loan loan = loans.Find(l => l.Book.Isbn == isbn && l.ReturnDate == null);
            if (loan == null)
            {
                Console.WriteLine("Loan not found!");
                return;
            }
            loan.ReturnBook();
            loan.Book.IsAvailable = true;

            Console.WriteLine($"Book '{loan.Book.Title}' returned");
        }
        public void ListAvailableBooks()
        {
            List<Book> availablebooks = books.FindAll(a => a.IsAvailable);
            foreach (Book book in availablebooks)
            {
                Console.WriteLine($"{book.Title} - {book.Author} (ISBN: {book.Isbn}) [Disponível]");
            }
        }
        public void ListActiveLoans()
        {
            List<Loan> activeloans = loans.FindAll(l => l.ReturnDate == null);
            foreach(Loan loan in activeloans)
            {
                Console.WriteLine($"{loan.Book.Title} -> {loan.Member.Name}");
                Console.WriteLine($"Empréstimo: {loan.LoanDate:dd/MM/yyyy} | Prazo: {loan.DueDate:dd/MM/yyyy}");
                Console.WriteLine("Não devolvido\n");
            }
        }
        public void ListOverdueLoans()
        {
            List<Loan> overdueloans = loans.FindAll(o => o.IsOverDue() == true);
            foreach (Loan loans in overdueloans)
            {
                Console.WriteLine($"Book {loans.Book.Title} from {loans.Member.Name}");
            }
        }
    }
}
