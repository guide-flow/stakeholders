using API.ServiceInterfaces;
using Common;
using Core.Domain.RepositoryInterfaces;
using Core.Mappers;
using Core.UseCases;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class StakeholdersStartup
    {
        public static IServiceCollection ConfigureStakeholders(this IServiceCollection services)
        {
            // Registers all profiles since it works on the assembly
            services.AddAutoMapper(typeof(StakeholdersProfile));
            SetupCore(services);
            SetupInfrastructure(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
        }

        private static void SetupInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(IUserProfileRepository),typeof(UserProfileRepository));

            services.AddDbContext<StakeholdersContext>(opt =>
                opt.UseNpgsql(Config.GetDbConnectionString(), x => x.MigrationsHistoryTable("__EFMigrationsHistory", "stakeholders")));
        }
    }
}
