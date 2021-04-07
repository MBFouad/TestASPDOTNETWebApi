using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_Core_Web_Api__1_.Data
{
    public class DBContext  : DbContext
    {
        public DBContext(DbContextOptions<DBContext> opt) : base(opt)
        {

        }

        public DbSet<Models.User> User { get; set; }


    }
}

