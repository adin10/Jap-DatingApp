using JapDatingApp.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Context
{
    public class MyContext : DbContext
    {
        public MyContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> User { get; set; }
    }
}
