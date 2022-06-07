using MediatR;

namespace Message.Dispatcher.Messages.Event.Commands;

public class AddOrUpdateEventCommand : IRequest<bool>
{
    public int ApiEventId { get; }
    public string AppKey { get; }
    public bool Visible { get; }

    public AddOrUpdateEventCommand(int apiEventId, string appKey, bool visible)
    {
        ApiEventId = apiEventId;
        AppKey = appKey;
        Visible = visible;
    }
}
