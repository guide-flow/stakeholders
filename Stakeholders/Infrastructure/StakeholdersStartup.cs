using API.ServiceInterfaces;
using Core.Domain.RepositoryInterfaces;
using Core.Mappers;
using Core.UseCases;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
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
            services.AddAutoMapper(typeof(StakeholdersProfile));
            SetupCore(services);
            SetupInfrastructure(services,connectionString);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
        }

        private static void SetupInfrastructure(IServiceCollection services, string connectionString)
        {
            services.AddScoped(typeof(IUserProfileRepository),typeof(UserProfileRepository));

            services.AddDbContext<StakeholdersContext>(opt =>
                opt.UseNpgsql(connectionString));
        }
    }
}
