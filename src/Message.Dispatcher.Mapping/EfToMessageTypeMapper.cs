using AutoMapper;
using Message.Dispatcher.Core.Entities;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Responses;

namespace Message.Dispatcher.Mapping;
public class EfToMessageTypeMapper : Profile
{
    public EfToMessageTypeMapper()
    {
        MappEventDomainTypes();
    }

    private void MappEventDomainTypes()
    {
        this.CreateMap<Event, EventDetailRespose>().ReverseMap();
    }
}
