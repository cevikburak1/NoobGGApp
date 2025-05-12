using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoobGGApp.Application.Common.Interfaces;
using NoobGGApp.Infrastructure.Persistence.EntityFramework.Context;
using NoobGGApp.Infrastructure.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
           .AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsHistoryTable("__ef_migrations_history"))
               .UseSnakeCaseNamingConvention());

            services
                .AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "NoobGGApp_";
            });
            services.AddSingleton<ICacheKeyFactory, CacheKeyFactory>();
            services.AddScoped<ICacheInvalidator, CacheInvalidator>();
            services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            return services;
        }
    }
}
