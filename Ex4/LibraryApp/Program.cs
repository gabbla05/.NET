using LibraryApp;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        Book book1 = new Book("C# Programming", "John Doe", "12345");
        Book book2 = new Book("Design Patterns", "Gamma et al.", "67890");
        EBook ebook1 = new EBook("Advanced C#", "Jane Smith", "11111", "PDF");

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(ebook1);

        Reader reader = new Reader(1, "Alice", "alice@example.com");
        library.RegisterReader(reader);

        Console.WriteLine("Available books:");
        library.ListAvailableBooks();

        Console.WriteLine("\nBorrowing book 12345...");
        if (library.BorrowBook("12345", reader))
            Console.WriteLine("Book borrowed successfully.");
        else
            Console.WriteLine("Book is not available.");

        Console.WriteLine("\nTrying to borrow again...");
        if (library.BorrowBook("12345", reader))
            Console.WriteLine("Book borrowed successfully.");
        else
            Console.WriteLine("Book is not available.");

        Console.WriteLine("\nReturning book...");
        if (library.ReturnBook("12345", reader))
            Console.WriteLine("Book returned successfully.");
        else
            Console.WriteLine("Failed to return book.");
    }
}
