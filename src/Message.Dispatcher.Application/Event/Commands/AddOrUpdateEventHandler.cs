using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Messages.Event.Commands;
using MediatR;
using Message.Dispatcher.Application.DTOs;
using Message.Dispatcher.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Message.Dispatcher.Application.Event.Commands;
public class AddOrUpdateEventHandler : IRequestHandler<AddOrUpdateEventCommand, bool>
{
    private readonly DispatcherDbContext _dbContext;
    private readonly IDataReader<EventDto> _dataReader;

    public AddOrUpdateEventHandler(DispatcherDbContext dbContext, IDataReader<EventDto> dataReader)
    {
        _dbContext = dbContext;
        _dataReader = dataReader;
    }

    public async Task<bool> Handle(AddOrUpdateEventCommand request, CancellationToken cancellationToken)
    {

        var apiEventsData = (await _dataReader.GetList($"/api/events/{request.AppKey}"))?.Data.FirstOrDefault();

        if (apiEventsData == null)
            return false;

        var dbEvent = await _dbContext.Events.Where(x => x.ApiEventId == request.ApiEventId).FirstOrDefaultAsync();

        if (dbEvent == null) {
            await this._dbContext.Events.AddAsync(
                new Core.Entities.Event()
                {
                    ApiEventId = apiEventsData.Id ,
                    Name = apiEventsData.Name,
                    Visible = request.Visible,
                    UtcDateStart = apiEventsData.DateStart,
                    UtcDateEnd = apiEventsData.DateEnd,
                    AppKey = request.AppKey
                }, cancellationToken);
        }
        else {
            dbEvent.Visible = request.Visible;
        }

        var saveChangesAsync = await this._dbContext.SaveChangesAsync();
        return true;
    }
}