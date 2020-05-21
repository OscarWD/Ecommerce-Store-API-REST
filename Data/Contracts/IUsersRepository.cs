using System.Collections.Generic;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data.Contracts
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
        void CreateUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(Users user);
        bool LoginUser(string email, string password);
        bool SaveChanges();
    }
}