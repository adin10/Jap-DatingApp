using JapDatingApp.Database;
using JapDatingApp.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JapDatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedUserController : ControllerBase
    {

        private readonly MyContext _context;
        public SeedUserController(MyContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            var user = new AppUser
            {
                Username ="lovro",
                Gender = "Male",
                City="Mostar",
                DateOfBirth=new DateTime(1995,4,28),
                CreatedDate=DateTime.Now,
                Country="BiH",
                FirstName="Lovro",
                LastName="Vidovic",
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
