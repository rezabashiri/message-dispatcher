using Message.Dispatcher.Core.Enums;
using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Commands;
using Message.Dispatcher.Share.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EventType = Message.Dispatcher.Core.Enums.EventType;

namespace Message.Dispatcher.Application.Event.Commands;

/// <summary>
/// Syncronise Event stored in database with api data 
/// </summary>
public class SyncEventHandler : IRequestHandler<SyncEventCommand, bool>
{
    private readonly IDispatcherDbContext _dbContext;

    public SyncEventHandler(IDispatcherDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<bool> Handle(SyncEventCommand request, CancellationToken cancellationToken)
    {

        var dbEvent = await _dbContext.Events.Where(x => x.ApiEventId == request.ApiEventId).FirstOrDefaultAsync() ?? new Core.Entities.Event() { ApiEventId = request.ApiEventId, AppKey = request.AppKey };

        dbEvent.Name = request.Name;
        dbEvent.UtcDateStart = request.StartTime.ToUniversalTime();
        dbEvent.UtcDateEnd = request.EndTime.ToUniversalTime();
        dbEvent.EventType = (Core.Enums.EventType)Enum.Parse(typeof(Core.Enums.EventType), request.EventType.ToString());

        if (dbEvent.Id == 0)
            _dbContext.Events.Add(dbEvent);

        var saveChangesAsync = await this._dbContext.SaveChangesAsync();
        return saveChangesAsync > 0;
    }
}