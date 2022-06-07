using Hangfire.Dashboard;

namespace Message.Dispatcher.Application.Hangfire
{
    internal class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Can be configured to avoid unauthorized usere
            //return context.GetHttpContext().Request.Cookies.ContainsKey("XXX");
            return true;
        }
    }
}