using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Models
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Add(User item);
        void Remove(int id);
        bool Update(User item);
    }
}
