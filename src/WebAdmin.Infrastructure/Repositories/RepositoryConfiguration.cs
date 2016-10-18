using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WebAdmin.Infrastructure.Context;

namespace WebAdmin.Infrastructure.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureServices(IConfigurationRoot configuration, IServiceCollection services)
        {
            services.AddDbContext<WebAdminContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]).EnableSensitiveDataLogging());

            //services.AddSingleton<IOrganisationDTOFactory, OrganisationFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddSingleton<IOrganisationRepository, OrganisationRepository>();
            //services.AddScoped<IUserDTOFactory, UserFactory>();
        }
    }
}