using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public interface IBookOperations
    {
        bool BorrowBook(string bookId, Reader borrower);
        bool ReturnBook(string bookId, Reader borrower);
    }

}
