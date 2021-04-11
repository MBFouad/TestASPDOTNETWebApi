using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_Core_Web_Api__1_.Data
{
   public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        void Save();
    }
}
