using System;

namespace LibraryExercice.Entites
{
    internal class Loan
    {
        public Book Book { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan(Book book, Member member)
        {
            this.Book = book;
            this.Member = member;
            LoanDate = DateTime.Now;
            DueDate = DateTime.Now.AddDays(14);
            ReturnDate = null;

            book.IsAvailable = false;
        }

        public void ReturnBook()
        {
            ReturnDate = DateTime.Now;
            Book.IsAvailable = true;
        }

        public bool IsOverDue()
        {
            if (ReturnDate != null)
            {
                return false;
            }
            else if (ReturnDate == null && DueDate > DateTime.Now)
            {
                return false;
            }
            else if (ReturnDate == null && DateTime.Now > DueDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetDaysLate()
        {
            if (IsOverDue() == false)
            {
                return 0;
            }
            else
            {
                return (int)(DateTime.Now - DueDate).TotalDays;
            }
        }
        public int GetLoanDuration()
        {
            if (ReturnDate != null)
            {
                return (int)(ReturnDate.Value - LoanDate).TotalDays;
            }
            else
            {
                return (int)(DateTime.Now - LoanDate).TotalDays;
            }
        }
        public override string ToString()
        {
            string returnInfo = ReturnDate == null
                ? "Não devolvido"
                : $"Devolvido em {ReturnDate.Value:dd/MM/yyyy}";

            string lateInfo = IsOverDue() ? $" ⚠️ ATRASADO {GetDaysLate()} dias" : "";

            return $"{Book.Title} → {Member.Name}\n" +
                   $"  Empréstimo: {LoanDate:dd/MM/yyyy} | Prazo: {DueDate:dd/MM/yyyy}\n" +
                   $"  {returnInfo}{lateInfo}";
        }
    }
}
