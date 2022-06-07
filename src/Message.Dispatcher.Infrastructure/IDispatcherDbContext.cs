using Message.Dispatcher.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Message.Dispatcher.Infrastructure;

public interface IDispatcherDbContext
{
    DbSet<Event> Events { get; set; }

     Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}