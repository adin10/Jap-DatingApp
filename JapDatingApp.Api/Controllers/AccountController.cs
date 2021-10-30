using JapDatingApp.Database;
using JapDatingApp.Infrastructure.Context;
using JapDatingApp.Infrastructure.DTOs;
using JapDatingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly ITokenService _service;
        public AccountController(MyContext context,ITokenService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>>Register(RegisterDTO request)
        {
            if(await UserExsist(request.Username))
            {
                return BadRequest("Username aleready exsist");
            }
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {

                Username = request.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return new UserDTO
            {
                Username = user.Username,
                Token = _service.createToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>>Login(LoginDTO request)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Username == request.Username);
            if (user == null)
            {
                return Unauthorized("Wrong username");
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("invalid password");
                }
            }
            return new UserDTO
            {
                Username = user.Username,
                Token = _service.createToken(user)
            };

        }
        private async Task<bool> UserExsist(string Username)
        {
            return await _context.User.AnyAsync(x => x.Username == Username.ToLower());
        }
    }
}
