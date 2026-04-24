
namespace LibraryExercice.Entites
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.Isbn = isbn;
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "Disponível" : "Emprestado";
            return $"{Title} - {Author} (ISBN: {Isbn}) [{status}]";
        }
    }
}
