using JapDatingApp.Database;
using JapDatingApp.Infrastructure.Context;
using JapDatingApp.Infrastructure.DTOs;
using JapDatingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
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

        private readonly IUserRepository _service;

            public UsersController(IUserRepository service)
            {
            _service = service;
            }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> GetUsers()
        {

            return Ok(await _service.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUserById(int id)
        {
            return Ok(await _service.GetUserByIdAsync(id));
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserUsername(string username)
        {
            return Ok(await _service.GetUserByUsernameAsync(username));
        }
    }
    
}
