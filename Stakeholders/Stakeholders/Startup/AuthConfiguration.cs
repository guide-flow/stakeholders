using Common;
using Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Stakeholders.Startup
{
    public static class AuthConfiguration
    {
        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = Config.GetIssuer();
            var audience = Config.GetAudience();
            var signingKey = Config.GetSecretKey();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("administratorPolicy", policy => policy.RequireRole("admin"));
                options.AddPolicy("touristPolicy", policy => policy.RequireRole("tourist"));
                options.AddPolicy("authorPolicy", policy => policy.RequireRole("author"));
            });
            return services;
        }

        public static void ApplyMigrations(this IApplicationBuilder app) {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StakeholdersContext>();
            dbContext.Database.Migrate();
        }
    }
}
