using JapDatingApp.Infrastructure.Context;
using JapDatingApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Extensions
{
   public static class ApplicationServiceExstensions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DB"));
                options.LogTo(x => Debug.Print(x));
            });
            return services;
        } 
    }
}
