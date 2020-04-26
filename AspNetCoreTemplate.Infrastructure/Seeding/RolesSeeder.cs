namespace AspNetCoreTemplate.Infrastructure.Seeding
{
    using AspNetCoreTemplate.Common;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class RolesSeeder : ISeeder
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesSeeder(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await this.SeedRoleAsync(ApplicationRoles.AdministratorRoleName);
        }

        private async Task SeedRoleAsync(string roleName)
        {
            IdentityRole roleExists = await this.roleManager.FindByNameAsync(roleName);

            if (roleExists == null)
            {
                await this.roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}