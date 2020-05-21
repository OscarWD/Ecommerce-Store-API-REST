using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceStoreAPI.Data.Contexts;
using EcommerceStoreAPI.Data.Contracts;
using EcommerceStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStoreAPI.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly EcommerceContext _context;

        public UsersRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void CreateUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
        }

        public void DeleteUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
        }

        public Users GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(predicate => predicate.Id == id);
        }

        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Entry(user).State = EntityState.Modified;
        }

        public bool LoginUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(predicate => predicate.Email == email);
            if (user == null)
                throw new ArgumentNullException(nameof(email));

            if (user.Password == password)
                return true;
            return false;

        }

    }
}