using Accentdesign.AA.Share.Model.Startup;
using Message.Dispatcher.Core.Entities;
using Message.Dispatcher.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Message.Dispatcher.Infrastructure.Seeders;
public class DispatcherSeeder : IDatabaseSeeder
{
    private readonly DispatcherDbContext _dbContext;


    public DispatcherSeeder(DispatcherDbContext dbContext)
    {
        _dbContext = dbContext;

        _dbContext.Database.Migrate();
    }

    public async Task Seed(int count)
    {
        //for (int i = 0; i < count; i++) {
        //    _dbContext.Events.Add(new Event() {
        //        Name = $"{DateTime.Now.AddDays(count).ToShortDateString()} event",
        //        ApiEventId = count,
        //        Visible = false,
        //        UtcDateStart = DateTime.UtcNow.AddDays(count),
        //        UtcDateEnd = DateTime.UtcNow.AddDays(count).AddHours(1),
        //        EventType = EventType.Conference
        //    });

        //}

        //await _dbContext.SaveChangesAsync();
    }
}

