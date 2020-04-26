namespace AspNetCoreTemplate.Infrastructure.Seeding
{
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync();
    }
}