using System.Reflection;
using Message.Dispatcher.Application.Helpers;
using Message.Dispatcher.Application.Jobs;
using Message.Dispatcher.Core.Jobs;
using Message.Dispatcher.Core.Jobs.Interfaces;
using Message.Dispatcher.Infrastructure.StartupSetup;
using MediatR;
using Message.Dispatcher.Application.Data;
using Message.Dispatcher.Application.Data.Http;
using Message.Dispatcher.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.StartupSetup
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration,
            string CronJobSeviceConnectionString,
            bool shallAddInfrastructureServices = true)
        {

            services.AddMediatR(new List<Assembly>() { AssemblyHelper.GetApplicationLayerAssembly() },
                configuration => { });

            services.AddSingleton(typeof(IDataReader<>), typeof(HttpReader<>))
                .AddSingleton<IKeepUptodateStoredEvents, KeepUptodateStoredEvents>()
                .AddHttpClient("fakeAPI", client =>
                {
                    client.BaseAddress = new Uri($"http://{configuration.GetSection("ApiConfiguration").GetValue<string>("Endpoint")}");
                });

            if (shallAddInfrastructureServices) {
                services.AddDispatcherPostgreInfrastructure(configuration);
            }

            if (!string.IsNullOrEmpty(CronJobSeviceConnectionString)) {
                services.AddCronJobProcessor(CronJobSeviceConnectionString);
            }

            return services;
        }

        public static void UseApplication(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseHangfireDashboard();

            DoJobs.DoAll(serviceProvider);
        }

    }
}
