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

            var roles = new List<string> { RoleConstants.AdminRole, RoleConstants.UserRole };

            foreach (var role in roles)
            {
                var existRole = await _roleManager.FindByNameAsync(role);

                if (existRole != null)
                    continue;

                var roleResult = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });
            }

            var existUser = await _userManager.FindByNameAsync("Admin");

            if (existUser != null)
            {
                return;
            }

            var user = new AppUser
            {
                UserName = "Admin",
                Email = "m.kubra1996@gmail.com",
                Fullname = "Admin",
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, "123456");

            result = await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);
        }
    }


}
