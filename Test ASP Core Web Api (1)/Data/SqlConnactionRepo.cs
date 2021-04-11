using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_ASP_Core_Web_Api__1_.Models;

namespace Test_ASP_Core_Web_Api__1_.Data
{

    public class SqlConnactionRepo : IUserRepo
    {
        private DBContext _context;

        public SqlConnactionRepo(DBContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Add(user);
        }

        public bool saveChnages()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
           // Nothing
        }

        User IUserRepo.GetAllUserById(int Id)
        {
            return _context.User.FirstOrDefault(p => p.Id == Id);
        }

        IEnumerable<User> IUserRepo.GetAllUsers()
        {
            return _context.User.ToList();
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.User.Remove(user);
        }
    }
}
