using Hangfire;
using Hangfire.Common;
using Message.Dispatcher.Core.Jobs.Interfaces;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Commands;
using Message.Dispatcher.Messages.Event.Queries;
using MediatR;

using Microsoft.Extensions.Configuration;

namespace Message.Dispatcher.Application.Jobs;
public class KeepUptodateStoredEvents : IKeepUptodateStoredEvents
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public KeepUptodateStoredEvents(IMediator mediator, IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _mediator = mediator;
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public async Task UpdateStoredEvents(string eventStatus)
    {

        var appKey = _configuration.GetSection("ApiConfiguration").GetValue<string>("AppKey");

        var apiEvents = await _mediator.Send(new EventListByAppKeyQuery(appKey));

        foreach (var apiEvent in apiEvents.ToList()) {
            await _mediator.Send(
               new SyncEventCommand(
                   apiEvent.Name,
                   apiEvent.DateStart,
                   apiEvent.DateEnd,
                   apiEvent.ApiEventId,
                   apiEvent.Type,
                   appKey));
        }

    }
}