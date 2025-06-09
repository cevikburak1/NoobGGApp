using Microsoft.EntityFrameworkCore;
using NoobGGApp.Infrastructure.Persistence.EntityFramework.Context;
using NoobGGApp.Infrastructure.Persistence.EntityFramework.Contexts;

namespace NoobGG.WebApi;

    public static class ApplicationBuilderExtensions
    {
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();

        return app;
    }
}

