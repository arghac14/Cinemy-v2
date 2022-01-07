using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Repositories;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using System.Security.Claims;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace IMDBapp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Get()
        {
            return _userRepository.Get();
        }

        public User Get(int id)
        {
            return _userRepository.GetById(id);
        }
        public void Post(User user) 
        {
            _userRepository.Post(new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = user.AccessToken,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            }); 
        }

        public void Signup(User user)
        {
            var userData = (User) null;
            try
            {
                userData = _userRepository.GetByEmail(user.Email);
            }
            catch
            {
                
            }

            if(userData != null)
            {
                throw new Exception("User Already Exists");
            }

            try
            {
                userData = _userRepository.GetByUserName(user.UserName);
            }

            catch
            {

            }

            if (userData != null)
            {
                throw new Exception("User Already Exists");
            }

            _userRepository.Post(new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = user.AccessToken,
                Password = user.Password,
                IsAdmin = user.IsAdmin ?? false
            });
        }

        public UserAuthResponse Login(User user)
        {
            var userData = (User)null;
            try
            {
                userData = _userRepository.Authenticate(user.UserName, user.Email, user.Password);
            }
            catch
            {
            }
            if (userData == null)
            {
                throw new Exception("User doesn't exist!");
            }

            var accessToken = BuildJWT(userData);

            user = _userRepository.GetByEmail(userData.Email);

            _userRepository.Put(user.Id, new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = accessToken,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            });

            var res = _userRepository.GetById(user.Id);

            return new UserAuthResponse()
            {
                UserId = res.Id,
                UserName = res.UserName,
                AccessToken = res.AccessToken,
                IsAdmin = res.IsAdmin
            };
        }

        public string BuildJWT(User user)
        {
            var portalDomain = "https://localhost:44303";
            // var authenticatedClaim = true;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, "User")
            }.ToList();

            var tokenExpiryDays = DateTime.UtcNow.AddDays(10);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz8YRWfRlVnz"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(portalDomain, null, claims, expires: tokenExpiryDays, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void Put(int id, User user)
        {
            _userRepository.Put(id, new User()
            {
                UserName = user.UserName,
                Email = user.Email,
                AccessToken = user.AccessToken,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            });  
        }
        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
