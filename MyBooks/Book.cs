using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBooks
{
    class Book
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Name { get; set; }
        public String Author { get; set; }
    }
}
