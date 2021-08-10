using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Identity
{
    public class DataInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataInitializer(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDataAsync()
        {
            #region RoleSeed

            var roles = new List<string>
            {
                RoleConstants.AdminRole,
                RoleConstants.ModeratorRole,
                RoleConstants.MemberRole
            };

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    continue;

                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            #endregion

            #region UserSeed

            var user = new AppUser
            {
                Email = "admin@gmail.com",
                UserName = "Admin",
                Name = "Admin",
                Surname = "Admin",
                City = "Bakı",
                SerialNumber = 1234567,
                BirthDay = DateTime.Now,
                FinCode = "test123",
                Address = "test",
                PhoneNumber = "123456",
                IsActive = true
            };

            if (await _userManager.FindByEmailAsync(user.Email) == null)
            {
                await _userManager.CreateAsync(user, "Admin@123");
                await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);
            }

            #endregion
        }
    }
}
