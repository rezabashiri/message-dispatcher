using System;
using System.Collections.Generic;
using Message.Dispatcher.Application.StartupSetup;
using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Share.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.IntegrationTests;

public class BaseTest
{
    protected readonly string _appKey = "2fdfg428b1c30ffa26hbfgh";
    protected readonly int _forBegginersEventId = 1;
    protected readonly string _eventName = "C# for beginners";

    protected ServiceProvider ServiceProvider { get; private set; }

    public BaseTest()
    {
        BuildServices(new ServiceCollection());
    }

    protected virtual IServiceCollection BuildServices(IServiceCollection services)
    {

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("ApiConfiguration:Endpoint","localhost:9002"),
                new KeyValuePair<string, string>("ApiConfiguration:AppKey","2fdfg428b1c30ffa26hbfgh"),

            }).Build();

        services.AddSingleton<IConfiguration>(provider => configuration)
            .AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddApplicationServices(configuration, "", false);

        services.AddDbContext<DispatcherDbContext>(options =>
        {
            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        });

        services
            .AddScoped<IDispatcherDbContext, DispatcherDbContext>()
            .AddMappers();
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }


}

