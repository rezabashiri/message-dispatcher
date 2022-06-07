using Message.Dispatcher.Application.StartupSetup;
using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Share.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.UnitTests
{
    public class BaseTest
    {
        protected ServiceProvider ServiceProvider { get; private set; }

        public BaseTest()
        {
            BuildServices(new ServiceCollection());
        }

        protected virtual IServiceCollection BuildServices(IServiceCollection services)
        {
            var p = Path.GetRelativePath("/", "../../src/Message.Dispatcher.Web/appsettings.json");
            var configuration = new ConfigurationBuilder().AddJsonFile(Path.GetFullPath("../../../../../src/Message.Dispatcher.Web/appsettings.json"));

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>()
                .AddMappers()
                .AddSingleton<IConfiguration>(provider => configuration.Build());

            services.AddDbContext<DispatcherDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });
            ServiceProvider = services.BuildServiceProvider();

            return services;
        }
    }
}