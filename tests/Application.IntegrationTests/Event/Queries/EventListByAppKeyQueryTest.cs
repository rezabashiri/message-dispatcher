using System.Threading.Tasks;
using FluentAssertions;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Application.IntegrationTests;
using Message.Dispatcher.Messages.Event.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Message.Dispatcher.Application.IntegrationTests.Event.Queries;

public class EventListByAppKeyQueryTest : BaseTest
{
    private IMediator _mediator;

    public EventListByAppKeyQueryTest()
    {
        _mediator = ServiceProvider.GetService<IMediator>();
    }

    [Fact]
    public async Task Handle_EventListByAppId_ShouldQueryApiAndReturnEventList()
    {
        var result = await _mediator.Send(new EventListByAppKeyQuery(_appKey));

        result.Should().NotBeEmpty("app key is valid");
    }
}
