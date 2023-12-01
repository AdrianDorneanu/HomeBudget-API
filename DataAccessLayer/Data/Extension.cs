using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataAccessLayer.Data
{
    public static class Extension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateAsyncScope();

            var services = scope.ServiceProvider;
            var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();

            applicationDbContext.Database.EnsureCreated();

            DBInitializer.InitializeDatabase(applicationDbContext);
        }
    }
}
