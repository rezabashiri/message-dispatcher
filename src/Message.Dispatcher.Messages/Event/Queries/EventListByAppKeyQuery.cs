using Message.Dispatcher.Messages.Event.Responses;
using MediatR;

namespace Message.Dispatcher.Messages.Event.Queries;

public class EventListByAppKeyQuery : IRequest<List<EventListByAppKeyResponse>>
{

    public EventListByAppKeyQuery(string appKey)
    {
        AppKey = appKey;
    }

    public string AppKey { get; }
}