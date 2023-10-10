using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }
        public int BookCount { get; set; }
    }
}