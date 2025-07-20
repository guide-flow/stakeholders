using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class StakeholdersStartup
    {
        public static IServiceCollection ConfigureStakeholders(this IServiceCollection services, string connectionString)
        {
            // Registers all profiles since it works on the assembly
            //services.AddAutoMapper(typeof().Assembly);
            SetupCore(services);
            SetupInfrastructure(services,connectionString);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {

        }

        private static void SetupInfrastructure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StakeholdersContext>(opt =>
                opt.UseNpgsql(connectionString));
        }
    }
}
