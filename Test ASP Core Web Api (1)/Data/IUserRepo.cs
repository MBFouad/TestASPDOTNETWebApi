using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_Core_Web_Api__1_.Data
{
   public interface IUserRepo
    {
        bool saveChnages();
        IEnumerable<Models.User> GetAllUsers();
        Models.User GetAllUserById(int Id);

        void CreateUser(Models.User user);
        void UpdateUser(Models.User user);

        void DeleteUser(Models.User user);
    }
}
