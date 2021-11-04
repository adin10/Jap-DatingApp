using JapDatingApp.Database;
using JapDatingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Services
{
   public interface IUserRepository
    {
        public Task<MemberDto> GetUserByIdAsync(int id);

        public Task<MemberDto> GetUserByUsernameAsync(string username);
        public Task<List<MemberDto>> GetUsersAsync();

        public Task<AppUser> Update(string username, MemberUpdateDto member);

        public Task<bool> SaveAllAsync();

       
    }
}
