using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_Core_Web_Api__1_.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext _context;
        private IUserRepo _userRepo;


        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        public IUserRepo UserRepo
        {
            get
            {
                return _userRepo = _userRepo ?? new SqlConnactionRepo(_context);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
