using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksApp.Controllers
{
    public class BooksController : ApiController
    {
        static readonly IBooksRepository repository = new BooksRepository();

        public IEnumerable<Book> GetAllBooks()
        {
            return repository.GetAll();
        }

        public IHttpActionResult GetBook(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(item);
        }

        public IHttpActionResult PostBook(Book item)
        {
            item = repository.Add(item);
            string uri = Url.Link("DefaultApi", new { id = item.BookId });
            return Created(new Uri(uri), item);
        }

        public void PutBook(int id, Book product)
        {
            product.BookId = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteBook(int id)
        {
            Book item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }

    }
}
