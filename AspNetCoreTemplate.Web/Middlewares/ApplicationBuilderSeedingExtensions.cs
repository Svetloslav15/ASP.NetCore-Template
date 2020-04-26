namespace AspNetCoreTemplate.Web.Middlewares
{
    using AspNetCoreTemplate.Infrastructure;
    using AspNetCoreTemplate.Infrastructure.Seeding;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using System.Linq;
    using System.Reflection;

    public static class ApplicationBuilderSeedingExtensions
    {
        public static void UseDatabaseSeeding(this IApplicationBuilder app)
        {
            using (var scopeService = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext dbContext = scopeService.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                Assembly.GetAssembly(typeof(ApplicationDbContext))
                          .GetTypes()
                          .Where(type => typeof(ISeeder).IsAssignableFrom(type))
                          .Where(type => type.IsClass)
                          .Select(type => (ISeeder)scopeService.ServiceProvider.GetRequiredService(type))
                          .OrderByDescending(type => nameof(type))
                          .ToList()
                          .ForEach(seeder =>
                          {
                              seeder.SeedAsync()
                                        .GetAwaiter()
                                        .GetResult();
                          });
            }
        }
    }
}