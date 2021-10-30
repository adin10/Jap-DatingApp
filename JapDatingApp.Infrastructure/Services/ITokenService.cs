using JapDatingApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Services
{
   public interface ITokenService
    {
        string createToken(AppUser user);
    }
}
