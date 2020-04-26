namespace AspNetCoreTemplate.Infrastructure.Seeding
{
    using AspNetCoreTemplate.Common;
    using AspNetCoreTemplate.Infrastructure.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersSeeder : ISeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public UsersSeeder(UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task SeedAsync()
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = this.configuration.GetConnectionString(GlobalConstants.AdminEmail),
                Email = this.configuration.GetConnectionString(GlobalConstants.AdminEmail),
            };

            string userPassword = this.configuration.GetConnectionString(GlobalConstants.AdminPassword);

            IdentityResult userResult = await this.userManager.CreateAsync(user, userPassword);
            if (userResult.Succeeded)
            {
                IdentityResult roleResult = await this.userManager.AddToRoleAsync(user, ApplicationRoles.AdministratorRoleName);
            }
            else
            {
                throw new Exception(string.Join(Environment.NewLine, userResult.Errors.Select(e => e.Description)));
            }
        }
    }
}