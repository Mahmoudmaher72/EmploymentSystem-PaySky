using EmploymentSystem.Application.Interfaces;
using EmploymentSystem.Domain.IRepositories;
using EmploymentSystem.Infrastructure.Context;
using EmploymentSystem.Infrastructure.Repositories;
using EmploymentSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EmploymentSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmploymentSystem"), b => b.MigrationsAssembly("EmploymentSystem.Infrastructure"));
            });

            services.AddSingleton(Log.Logger);
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtService, JwtService>();
            
            return services;
        }
    }
}
