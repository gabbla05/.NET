using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Reader
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Reader(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
