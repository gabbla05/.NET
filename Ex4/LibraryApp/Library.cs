using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    using System.Collections.Generic;
    using System.Linq;

    public class Library : IBookOperations
    {
        private List<Book> books = new();
        private List<Reader> readers = new();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RegisterReader(Reader reader)
        {
            readers.Add(reader);
        }

        public void ListAvailableBooks()
        {
            foreach (var book in books.Where(b => b.IsAvailable))
            {
                book.DisplayInfo();
            }
        }

        public bool BorrowBook(string bookId, Reader borrower)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsAvailable)
            {
                book.IsAvailable = false;
                return true;
            }
            return false;
        }

        public bool ReturnBook(string bookId, Reader borrower)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && !book.IsAvailable)
            {
                book.IsAvailable = true;
                return true;
            }
            return false;
        }
    }

}
