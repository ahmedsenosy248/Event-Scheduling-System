using EventSchedulingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingSystem.Shared
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder application)
        {
            using IServiceScope scope = application.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
