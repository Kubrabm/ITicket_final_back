using ITicket.DAL.DataContext;
using ITicket.DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITicket.DAL.Data
{
    public class DataInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _dbcontext;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbcontext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbcontext = dbcontext;
        }

        public async Task SeedData()
        {
            await _dbcontext.Database.MigrateAsync();

            var roles = new List<string> { RoleConstants.AdminRole, RoleConstants.MemberRole };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));

                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            Console.WriteLine($"Rol yaratma səhvi {role}: {error.Description}");
                        }
                    }
                }
            }
            var adminUserName = "Admin";
            var adminUser = await _userManager.FindByNameAsync(adminUserName);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminUserName,
                    Email = "admin@code.edu.az",
                    FirstName = "Admin",
                    LastName = "Admin",
                };

                var result = await _userManager.CreateAsync(adminUser, "12345678aA");

                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(adminUser, RoleConstants.AdminRole);

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"{error.Description}");
                    }
                }
            }
            else
            {

            }
        }
    }

}
