using AutoMapper;
using Message.Dispatcher.Application.DTOs;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Responses;

namespace Message.Dispatcher.Mapping
{
    public class DTOsToMessagesMapper : Profile
    {
        public DTOsToMessagesMapper()
        {
            this.CreateMap<EventDto, EventListByAppKeyResponse>()
                .ForMember(x => x.Visible, opt => opt.Ignore())
                .ForMember(x => x.ApiEventId, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Id % 2 == 0 ? EventType.Conference : EventType.Greeting));
        }
    }
}