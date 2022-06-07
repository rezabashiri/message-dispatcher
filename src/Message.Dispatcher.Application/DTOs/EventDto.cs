using Message.Dispatcher.Share.Contracts;
namespace Message.Dispatcher.Application.DTOs;
public record EventDto(int Id, DateTime DateStart, DateTime DateEnd, string Name, string AppKey) : IEventContract
{
}