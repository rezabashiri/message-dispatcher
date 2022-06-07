namespace Message.Dispatcher.Core.Jobs.Interfaces;
public interface IKeepUptodateStoredEvents
{
    public Task UpdateStoredEvents(string eventStatus);
}
