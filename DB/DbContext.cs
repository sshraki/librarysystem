using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BooksApp.Models;
namespace BooksApp.DB
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public LibraryDBContext()
        {
            this.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}