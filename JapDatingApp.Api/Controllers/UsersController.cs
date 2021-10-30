using JapDatingApp.Database;
using JapDatingApp.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapDatingApp.Api.Controllers
{
 
    public class UsersController : BaseController
    {
     
            private readonly MyContext _context;

            public UsersController(MyContext context)
            {
                _context = context;
            }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {

            return await _context.User.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }
    }
    
}
