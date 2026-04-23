using System;


namespace exercice.Entities
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int  Year { get; set; }
        public double Price { get; set; }
        public BookCategory Category { get; set; }

        public Book()
        {
        }

        public Book(string title, string author, int year, double price, BookCategory category)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Price = price;
            this.Category = category;
        }
        public int GetAge()
        {
            int now = DateTime.Now.Year;
            return now - Year;
        }

        public double GetDiscount()
        {
            int age = GetAge();

            if (age < 5)
                return 0.0;

            else if (age <= 10)
                return 0.10;

            else
                return 0.20;
        }
        public double GetFinalPrice()
        {
            double discount = GetDiscount();
            return Price -= Price * discount;
        }
        public override string ToString()
        {
            return
                $"{Title} - {Author} ({Year})\n" +
                $"Categoria: {Category}\n" +
                $"Idade: {GetAge()} anos\n" +
                $"Preço original: R$ {Price:F2}\n" +
                $"Desconto: {(GetDiscount() * 100):F0}%\n" +
                $"Preço final: R$ {GetFinalPrice():F2}\n";
        }

    }
}
