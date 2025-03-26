using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class EBook : Book
    {
        public string FileFormat { get; private set; }

        public EBook(string title, string author, string id, string fileFormat)
            : base(title, author, id)
        {
            FileFormat = fileFormat;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Format: {FileFormat}");
        }
    }
}

