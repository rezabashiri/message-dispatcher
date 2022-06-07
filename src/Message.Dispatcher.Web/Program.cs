using Message.Dispatcher.Application.StartupSetup;
using Message.Dispatcher.Share.Providers;
using Message.Dispatcher.Web.StartupSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenIdConnect(builder.Configuration, builder.Environment)
    .AddHttpClients(builder.Configuration, builder.Environment)
    .AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(60);
    })
    .AddApplicationServices(builder.Configuration, builder.Configuration.GetConnectionString("HangfireConnection"))
    .AddMappers()
    .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()

    .AddScoped(x =>
    {
        ActionContext actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
        IUrlHelperFactory factory = x.GetRequiredService<IUrlHelperFactory>();

        return factory.GetUrlHelper(actionContext);
    })

    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
    .AddRazorPages(options =>
    {
        options.Conventions.AddAreaPageRoute("Admin", "/Event/Index", "/admin");
        options.Conventions.AddAreaPageRoute("Admin", "/Event/Index", "");
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//if (app.Environment.IsProduction())
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();


app.UseApplication(app.Services);

app.UseAuthorization();

app.MapRazorPages();

app.Run();
