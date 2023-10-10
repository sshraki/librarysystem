using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksApp.Models
{
    public class UsersRepository : IUsersRepository
    {
        private List<User> Users;

        public UsersRepository()
        {
            Users = new List<User>(new User[] 
            { 
               
            });
        }

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User Get(int id)
        {
            return Users.FirstOrDefault(p => p.UserId == id);
        }

        public User Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Users.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Users.RemoveAll(p => p.UserId == id);
        }

        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Users.FindIndex(p => p.UserId == item.UserId);
            if (index == -1)
            {
                return false;
            }
            Users.RemoveAt(index);
            Users.Add(item);
            return true;
        }
    }
}