using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;

namespace IMDBapp.Services
{
    public interface IUserService
    {
        public IEnumerable<User> Get();
        public UserAuthResponse Login(User user);
        public void Signup(User user);
        public User Get(int id);
        public void Post(User user);
        public void Put(int id, User user);
        public void Delete(int id);
        public string BuildJWT(User user);
    }
}
