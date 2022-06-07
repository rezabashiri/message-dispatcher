using FluentAssertions;
using Message.Dispatcher.Application.Jobs;
using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Core.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Message.Dispatcher.Application.IntegrationTests.Jobs
{
    public class KeepUptodateStoredEventsTest : BaseTest
    {
        private KeepUptodateStoredEvents _sut;
        private IDispatcherDbContext _context;

        public KeepUptodateStoredEventsTest()
        {
            _context = ServiceProvider.GetService<IDispatcherDbContext>();
            _sut = new KeepUptodateStoredEvents(ServiceProvider.GetService<IMediator>(), ServiceProvider.GetService<IConfiguration>(), ServiceProvider );
        }

        [Fact]
        public async Task UpdateStoredEvents_ExistsEventInDataBase_ShouldSyncData()
        {
            await _context.Events.AddAsync(new Core.Entities.Event() {
                AppKey = _appKey,
                ApiEventId = _forBegginersEventId, 
                Name = "Not Synced"
            });
            await _context.SaveChangesAsync();

            await _sut.UpdateStoredEvents(string.Empty);

            var updatedEvent = await _context.Events.FirstOrDefaultAsync(x => x.ApiEventId == _forBegginersEventId);
            updatedEvent.Name.Should().Be(_eventName);
        }

        [Fact]
        public async Task UpdateStoredEvents_ExistsEventAndEventAttendeeInDataBase_ShouldSetEventType()
        {
            await _context.Events.AddAsync(new Core.Entities.Event()
            {
                AppKey = _appKey,
                ApiEventId = _forBegginersEventId,
                Name = _eventName,
            });

            await _context.SaveChangesAsync();

            await _sut.UpdateStoredEvents(string.Empty);

            var updatedEvent = await _context.Events.FirstOrDefaultAsync(x => x.ApiEventId == _forBegginersEventId);

            updatedEvent.EventType.Should().Be(EventType.Greeting);
        }
    }
}