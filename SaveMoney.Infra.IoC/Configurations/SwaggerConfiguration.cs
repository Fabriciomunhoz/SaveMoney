using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace SaveMoney.Infra.IoC.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaveMoney.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"Jwt Authorization header using the Bearer scheme. Enter 'Bearer'
                                    and then your token in the text input below. Example: 'Bearer 12345abcdefg.123'"
                });

                c.AddSecurityRequirement(x => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", x)] = []
                });
            });

            return services;
        }
    }
}
