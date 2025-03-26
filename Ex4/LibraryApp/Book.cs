using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author, string id)
        {
            Title = title;
            Author = author;
            Id = id;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Title} by {Author} - {(IsAvailable ? "Available" : "Borrowed")}");
        }
    }
}

