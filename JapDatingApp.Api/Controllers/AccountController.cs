using JapDatingApp.Api.Controllers;
using JapDatingApp.Database;
using JapDatingApp.Infrastructure;
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

namespace JapDatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly MyContext _context;
        private readonly ITokenService _service;


        public AccountController(MyContext context, ITokenService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO register)
        {
            if (await UserExists(register.Username))
            {
                return BadRequest("Username already exstist");
            }

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                Username = register.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)).ToString(),
                PasswordSalt = hmac.Key.ToString()
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new UserDTO
            {
                Username = user.Username,
                Token = _service.createToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            byte[] bytesPasswordSalt = System.Text.Encoding.Unicode.GetBytes(user.PasswordSalt);

            using var hmac = new HMACSHA512(bytesPasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDTO
            {
                Username = user.Username,
                Token = _service.createToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username.ToLower());

        }
    }
}