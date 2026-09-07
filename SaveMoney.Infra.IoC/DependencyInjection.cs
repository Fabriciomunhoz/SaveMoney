using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaveMoney.Application;
using SaveMoney.Application.Mappings;
using SaveMoney.Infra.IoC.Configurations;
using SaveMoney.Infra.IoC.Services;

namespace SaveMoney.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDbContextConfiguration(configuration)
                .AddAutoMapper(cfg => { },
                    typeof(DomainToDTOMappingProfile).Assembly)
                .AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(
                        typeof(ApplicationAssemblyMarker).Assembly))
                .AddServicesConfiguration();

            return services;
        }
    }
}
