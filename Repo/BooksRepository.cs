using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksApp.Models
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> books;

        public BooksRepository()
        {
            books = new List<Book>(new Book[] 
            { 
               
            });
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(p => p.BookId == id);
        }

        public Book Add(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            books.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            books.RemoveAll(p => p.BookId == id);
        }

        public bool Update(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = books.FindIndex(p => p.BookId == item.BookId);
            if (index == -1)
            {
                return false;
            }
            books.RemoveAt(index);
            books.Add(item);
            return true;
        }
    }
}