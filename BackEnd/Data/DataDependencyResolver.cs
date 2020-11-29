using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class DataDependencyResolver
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ElectricityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ElectricityContext"),
                b => b.MigrationsAssembly("Data"));
                options.EnableDetailedErrors();
            });
        }
    }
}
