using System.Collections.Generic;
using DoggyCare.Models;

namespace DoggyCare.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string username, string password);
        void CreateUser(User user);
        User GetUser(int id);
    }
}
