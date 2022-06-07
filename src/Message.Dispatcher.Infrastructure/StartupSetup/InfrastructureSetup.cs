using Accentdesign.AA.Share.Model.Startup;
using Message.Dispatcher.Infrastructure.Backgrounds;
using Message.Dispatcher.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Infrastructure.StartupSetup
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection AddDispatcherPostgreInfrastructure(this IServiceCollection servicies, IConfiguration configuration)
        {

            servicies.AddDbContext<DispatcherDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Message.DispatcherConnection"));
            });
            servicies.AddScoped<IDatabaseSeeder, DispatcherSeeder>()
                .AddScoped<IDispatcherDbContext,DispatcherDbContext>()
                .AddHostedService<SeedDatabase>();
            return servicies;
        }
    }
}
