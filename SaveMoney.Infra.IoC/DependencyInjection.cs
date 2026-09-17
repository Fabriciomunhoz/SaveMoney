using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaveMoney.Application;
using SaveMoney.Application.Mappings;
using SaveMoney.Infra.IoC.Configurations;

namespace SaveMoney.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextConfiguration(configuration);
            services.AddSwaggerConfiguration();
            services.AddControllers();
            services.AddAutoMapper(cfg => { },
                typeof(DomainToDTOMappingProfile).Assembly);
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(
                    typeof(ApplicationAssemblyMarker).Assembly));
            services.AddSecurityConfiguration(configuration);
            services.AddServicesConfiguration();

            return services;
        }
    }
}
