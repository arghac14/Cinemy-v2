using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models.Request;
using IMDBapp.Models;

namespace IMDBapp.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> Get();
        public User GetById(int id);
        public void Post(User user);
        public void Put(int id, User user);
        public void Delete(int id);
        public User GetByUserName(string userName);
        public User GetByEmail(string email);
        public User Authenticate(string username, string email, string password);
    }
}
