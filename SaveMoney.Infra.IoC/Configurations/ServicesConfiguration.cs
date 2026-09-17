using Microsoft.Extensions.DependencyInjection;
using SaveMoney.Application.Interfaces;
using SaveMoney.Application.Services;
using SaveMoney.Domain.Account;
using SaveMoney.Domain.Interfaces;
using SaveMoney.Infra.Data.Identity;
using SaveMoney.Infra.Data.Repositories;

namespace SaveMoney.Infra.IoC.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
            services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            return services;
        }
    }
}
