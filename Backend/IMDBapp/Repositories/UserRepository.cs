using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;

namespace IMDBapp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionString _connectionString;
        public UserRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<User> Get()
        {
            string query = 
                @" SELECT * 
                FROM Users";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<User>(query);
            return res;
        }

        public User GetById(int id)
        {
            string query = 
                @"SELECT * 
                FROM Users 
                WHERE Id = @Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<User>(query, new { Id = id });
            return res;
        }

        public User GetByEmail(string email)
        {
            string query =
                @"SELECT * 
                FROM Users 
                WHERE Email = @Email";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<User>(query, new { Email = email });
            return res;
        }

        public User GetByUserName(string userName)
        {
            string query =
                @"SELECT * 
                FROM Users 
                WHERE Username = @UserName";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<User>(query, new { UserName = userName });
            return res;
        }

        public User Authenticate(string userName, string email, string password)
        {
            string query =
                @"SELECT * 
                FROM Users 
                WHERE (Email = @Email AND Password = @Password) OR (Username = @Username AND Password = @Password)";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<User>(query, new { UserName = userName , Email = email, Password = password });
            return res;
        }

        public void Post(User user)
        {
            string query =
                @"INSERT INTO 
                 Users (
                 UserName
                ,Password
                ,Email
                ,AccessToken
                ,IsAdmin
                )
                VALUES(
                   @UserName
                  ,@Password
                  ,@Email
                  ,@AccessToken
                  ,@IsAdmin
                );";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new
                {
                    @UserName = user.UserName,
                    @Email = user.Email,
                    @Password = user.Password,
                    @AccessToken = user.AccessToken,
                    @IsAdmin = user.IsAdmin
            });
        }

        public void Put(int id, User user)
        {
            string query = 
            @"UPDATE Users
            SET
                UserName=@UserName,
                Password=@Password,
                AccessToken=@AccessToken,
                IsAdmin=@IsAdmin
            WHERE Users.Id=@id";

           var connection = new SqlConnection(_connectionString.IMDBDB);
           connection.Execute(query, new
                {
                    id,
                    user.UserName,
                    user.Email,
                    user.Password,
                    user.AccessToken,
                    user.IsAdmin
                });
        }

        public void Delete(int id)
        {
            string sql = @"
            DELETE from 
            Users
            WHERE Id=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(sql, new { @Id = id });
            
        }
    }
}
