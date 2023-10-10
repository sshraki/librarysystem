using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksApp.Controllers
{
    public class UsersController : ApiController
    {
        static readonly IUsersRepository repository = new UsersRepository();

        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public IHttpActionResult GetUser(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(item);
        }

        public IHttpActionResult PostUser(User item)
        {
            item = repository.Add(item);
            string uri = Url.Link("DefaultApi", new { id = item.UserId });
            return Created(new Uri(uri), item);
        }

        public void PutUser(int id, User product)
        {
            product.UserId = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(int id)
        {
            User item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }

    }
}
