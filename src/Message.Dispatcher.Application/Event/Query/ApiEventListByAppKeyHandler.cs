using AutoMapper;
using Message.Dispatcher.Messages.Event.Queries;
using Message.Dispatcher.Messages.Event.Responses;
using MediatR;
using Message.Dispatcher.Application.DTOs;
using Message.Dispatcher.Application.Interfaces;
using Message.Dispatcher.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Message.Dispatcher.Application.Event.Query
{
    public class ApiEventListByAppKeyHandler : IRequestHandler<EventListByAppKeyQuery, List<EventListByAppKeyResponse>>
    {
        private readonly IDataReader<EventDto> _dataReader;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IDispatcherDbContext _dbContext;

        public ApiEventListByAppKeyHandler(IDataReader<EventDto> dataReader, IMapper mapper, IMediator mediator, IDispatcherDbContext dbContext)
        {
            _dataReader = dataReader;
            _mapper = mapper;
            _mediator = mediator;
            _dbContext = dbContext;
        }
        public async Task<List<EventListByAppKeyResponse>> Handle(EventListByAppKeyQuery request, CancellationToken cancellationToken)
        {
            var containers = await _dataReader.GetList($"/api/events/{request.AppKey}");

            var storedEvents = await _dbContext.Events.Where(x=>x.AppKey == request.AppKey).ToListAsync();

            return containers.Data.Select(x =>
            {
                var apiRecord = _mapper.Map<EventListByAppKeyResponse>(x);
                var storedDetail = storedEvents?.Find(stored => stored.ApiEventId == x.Id);
                apiRecord.Visible = storedDetail?.Visible ?? false;
                return apiRecord;
            }).ToList();
        }
    }

}
