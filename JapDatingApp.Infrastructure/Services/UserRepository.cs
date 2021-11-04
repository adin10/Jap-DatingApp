using AutoMapper;
using JapDatingApp.Database;
using JapDatingApp.Infrastructure.Context;
using JapDatingApp.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        public UserRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MemberDto> GetUserByIdAsync(int id)
        {
            var entity = await _context.User.FindAsync(id);
            return _mapper.Map<MemberDto>(entity);
        }

        public async Task<MemberDto> GetUserByUsernameAsync(string username)
        {
            var entity = await _context.User.SingleOrDefaultAsync(x => x.Username == username);
            return _mapper.Map<MemberDto>(entity);
        }

        public async Task<List<MemberDto>> GetUsersAsync()
        {
            var list = await _context.User.Include(p=>p.Photos).ToListAsync();
            return _mapper.Map<List<MemberDto>>(list);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
