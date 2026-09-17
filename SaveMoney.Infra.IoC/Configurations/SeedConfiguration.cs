using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SaveMoney.Domain.Account;

namespace SaveMoney.Infra.IoC.Configurations
{
    public static class SeedConfiguration
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var seedUserRoleInitial =
                scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();

            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();
        }
    }
}
