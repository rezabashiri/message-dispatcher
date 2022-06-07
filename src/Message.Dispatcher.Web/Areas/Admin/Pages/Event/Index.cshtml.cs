using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Queries;
using Message.Dispatcher.Messages.Event.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Message.Dispatcher.Web.Areas.Admin.Pages.Event
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public List<EventListByAppKeyResponse> Events { get; set; }


        public IndexModel(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        public async Task OnGet()
        {
            this.Events = await _mediator.Send(new EventListByAppKeyQuery(_configuration.GetSection("ApiConfiguration:AppKey").Value));
        }
    }
}
