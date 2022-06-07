using AutoMapper;
using FluentAssertions;
using Message.Dispatcher.Application.Event.Query;
using Message.Dispatcher.Messages.Event.Queries;
using Message.Dispatcher.Messages.Event.Responses;
using MediatR;
using Message.Dispatcher.Application.Data;
using Message.Dispatcher.Application.DTOs;
using Message.Dispatcher.Application.Interfaces;
using Message.Dispatcher.Infrastructure;
using Moq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Message.Dispatcher.Application.UnitTests.Event;

public class QueryEventListByAppIdTest : BaseTest
{
    private ApiEventListByAppKeyHandler _sut;
    private Mock<IDataReader<EventDto>> _dataReaderMock;
    private IMapper _mapper;
    private readonly DataReaderResponse<List<EventDto>> _apiListResponse;
    private Mock<IMediator> _mediator;
    private readonly Mock<IDispatcherDbContext> _dbContextMock;
    private readonly Mock<DbSet<Core.Entities.Event>> _dbSetMock = new Mock<DbSet<Core.Entities.Event>>();

    public QueryEventListByAppIdTest()
    {
        _mediator = new Mock<IMediator>();
        _mapper = ServiceProvider.GetService<IMapper>();
        _dbContextMock = new Mock<IDispatcherDbContext>();
        _dataReaderMock = new Mock<IDataReader<EventDto>>();

        _sut = new ApiEventListByAppKeyHandler(_dataReaderMock.Object, _mapper, _mediator.Object, _dbContextMock.Object);
        _apiListResponse = new DataReaderResponse<List<EventDto>>()
        {
            IsSuccess = true,
            Data = new List<EventDto>() {
                    new EventDto(
                          1,
                         DateTime.UtcNow ,
                        DateTime.UtcNow.AddHours(1) ,
                        "test 1","123")
                    ,
                    new EventDto(
                        2,
                        DateTime.UtcNow ,
                         DateTime.UtcNow.AddHours(1) ,
                        "test 2","123"
                    ),
                    new EventDto(
                        3,
                        DateTime.UtcNow ,
                        DateTime.UtcNow.AddHours(1) ,
                        "test 3","123"
                    ),
                }
        };
    }

    [Fact]
    public async Task Handle_EventListByAppId_ShouldQueryApiAndReturnEventList()
    {
        var databaseEvents = new List<Core.Entities.Event>();

        MockDbSet(databaseEvents);

        _dbSetMock.Setup(d => d.Add(It.IsAny<Core.Entities.Event>())).Callback<Core.Entities.Event>((s) => databaseEvents.Add(s));
        _dbContextMock.Setup(x => x.Events).Returns(_dbSetMock.Object);

        _dataReaderMock.Setup(x => x.GetList(It.IsAny<string>())).ReturnsAsync(_apiListResponse);
        var act = await _sut.Handle(new EventListByAppKeyQuery("TestKey"), default);

        act.Should().BeEquivalentTo(_apiListResponse.Data.Select(x => _mapper.Map<EventListByAppKeyResponse>(x))
            .ToList());
    }

    private void MockDbSet(List<Core.Entities.Event> databaseEvents)
    {
        _dbSetMock.As<IAsyncEnumerable<Core.Entities.Event>>().Setup(x => x.GetAsyncEnumerator(default))
            .Returns(new TestAsyncEnumerator<Core.Entities.Event>(databaseEvents.AsQueryable().GetEnumerator()));

        _dbSetMock.As<IQueryable<Core.Entities.Event>>().Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<Core.Entities.Event>(databaseEvents.AsQueryable().Provider));
        _dbSetMock.As<IQueryable<Core.Entities.Event>>().Setup(m => m.Expression)
            .Returns(databaseEvents.AsQueryable().Expression);
        _dbSetMock.As<IQueryable<Core.Entities.Event>>().Setup(m => m.ElementType)
            .Returns(databaseEvents.AsQueryable().ElementType);
        _dbSetMock.As<IQueryable<Core.Entities.Event>>().Setup(m => m.GetEnumerator())
            .Returns(() => databaseEvents.AsQueryable().GetEnumerator());
    }
}
