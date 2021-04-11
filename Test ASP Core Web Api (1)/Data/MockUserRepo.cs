using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_ASP_Core_Web_Api__1_.Models;

namespace Test_ASP_Core_Web_Api__1_.Data
{
    public class MockUserRepo : IUserRepo
    {

        private DBContext _context;

        public MockUserRepo(DBContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetAllUserById(int Id)
        {
            return new User { Id = 0, Name = "First Name", Adreess = "First Address", NationalId = "000000000000000000" };
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>
            {
                  new User { Id = 0, Name = "First Name", Adreess = "First Address", NationalId = "000000000000000000" },
                  new User { Id = 1, Name = "second Name", Adreess = "Second Address", NationalId = "111111111111111111111111" },
                  new User { Id = 3, Name = "Third Name", Adreess = "Third Address", NationalId = "222222222222222222" },

            };

            return users;
        }

        public bool saveChnages()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user) 
        {
            throw new NotImplementedException();
        }
    }
}
