using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreRad.Models
{
    public class IdentitySeedData
    {
        public static void SeedDataIdentity(IServiceProvider services,
            IWebHostEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var roleName = "Admin";
                var result = managerRole.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                string email = "admin@gmail.com";
                var user = new DbUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+38(066)666-66-66"
                };
                result = manager.CreateAsync(user, "qwerty-0").Result;
                result = manager.AddToRoleAsync(user, "Admin").Result;
            }
        }
    }
}
