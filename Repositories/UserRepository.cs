using System;
using System.Collections.Generic;
using System.Linq;
using DoggyCare.Models;

namespace DoggyCare.Repositories
{
    public class UserRepository : IUsersRepository
    {
        // TODO: List of users should be in a database and not in memory
        List<User> users = new()
        {
            new User { Id = 1, Username = "karl", Password = "karl", Role = "manager" },
            new User { Id = 2, Username = "luna", Password = "luna", Role = "employee" },
            new User { Id = 3, Username = "ole", Password = "ole", Role = "developer" }
        };

        // Return a single user
        public User GetUser(string username, string password)
        {
            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        }

        // Create a new user
        public void CreateUser(User user)
        {
            User newUser = user;
            newUser.Id = users.Last().Id++;

            users.Add(user);
        }

        // Return all users
        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        // Return a single user from ID
        public User GetUser(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}
