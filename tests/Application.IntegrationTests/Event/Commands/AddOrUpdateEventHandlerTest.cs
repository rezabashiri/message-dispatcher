using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Message.Dispatcher.Infrastructure;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Application.IntegrationTests;
using Message.Dispatcher.Messages.Event.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Dispatcher.Application.IntegrationTests.Event.Commands
{
    public class AddOrUpdateEventHandlerTest : BaseTest
    {
        private readonly IMediator _mediator;
        private readonly DispatcherDbContext dbContext;

        public AddOrUpdateEventHandlerTest()
        {
            _mediator = ServiceProvider.GetService<IMediator>();
            dbContext = ServiceProvider.GetService<DispatcherDbContext>();
        }

        [Fact]
        public async Task Handle_AddOrUpdateEventHandler_NoneInsertedEvent_ShouldInsertEvent()
        {
            var visible = true;
            var actual = await _mediator.Send(new AddOrUpdateEventCommand(_forBegginersEventId, _appKey, visible));

            var storedData = await dbContext.Events.Where(x => x.ApiEventId == _forBegginersEventId).FirstOrDefaultAsync();
            actual.Should().BeTrue();
            storedData.Visible.Should().Be(visible);
        }

    }
}
