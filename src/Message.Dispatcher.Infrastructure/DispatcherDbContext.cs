using Message.Dispatcher.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Message.Dispatcher.Infrastructure;

public class DispatcherDbContext : DbContext, IDispatcherDbContext
{
    public DispatcherDbContext(DbContextOptions<DispatcherDbContext> options) : base(options)
    {
     }

    public DbSet<Event> Events { get; set; }


    override protected void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties(typeof(Enum))
            .HaveConversion<string>();
    }
}

