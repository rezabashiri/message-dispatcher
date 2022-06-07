using MediatR;
using Message.Dispatcher.Messages.Event.Responses;

namespace Message.Dispatcher.Messages.Event.Commands;

public record SyncEventCommand(string Name, DateTime StartTime, DateTime EndTime, int ApiEventId, EventType EventType,string AppKey) : IRequest<bool>
{
}