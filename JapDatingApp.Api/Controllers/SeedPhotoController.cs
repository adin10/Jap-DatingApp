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
    public class SeedPhotoController : ControllerBase
    {
        private readonly MyContext _context;
        public SeedPhotoController(MyContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            var userPhoto = new Photo
            {
                Url= "https://randomuser.me/api/portraits/men/93.jpg",
                IsMain=true,
                AppUserId=5
            };
            await _context.Photo.AddAsync(userPhoto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
