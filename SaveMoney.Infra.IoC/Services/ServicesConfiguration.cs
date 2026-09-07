using Microsoft.Extensions.DependencyInjection;
using SaveMoney.Application.Interfaces;
using SaveMoney.Application.Services;
using SaveMoney.Domain.Interfaces;
using SaveMoney.Infra.Data.Repositories;

namespace SaveMoney.Infra.IoC.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
            return services;
        }
    }
}
