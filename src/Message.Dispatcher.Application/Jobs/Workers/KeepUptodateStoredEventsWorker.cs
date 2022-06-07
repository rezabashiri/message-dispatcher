using Hangfire;
using Message.Dispatcher.Core.Jobs.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.Jobs.Workers
{
    public class KeepUptodateStoredEventsWorker : IJob
    {
        private readonly IRecurringJobManager _jobManager;
        private readonly IKeepUptodateStoredEvents _keepUptodateStoredEvents;


        public KeepUptodateStoredEventsWorker(IServiceProvider serviceProvider)
        {
            _jobManager = serviceProvider.GetService<IRecurringJobManager>();
            _keepUptodateStoredEvents = serviceProvider.GetService<IKeepUptodateStoredEvents>();
        }

        public Task Todo()
        {
            _jobManager.AddOrUpdate("sync event detail every 10 minute", () => _keepUptodateStoredEvents.UpdateStoredEvents(string.Empty), "*/10 * * * *");

            return Task.CompletedTask;
        }
    }
}