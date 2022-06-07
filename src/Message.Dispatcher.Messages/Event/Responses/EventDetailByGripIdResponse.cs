
namespace Message.Dispatcher.Messages.Event.Responses
{
    public class EventDetailRespose
    {
        /// <summary>
        /// Gets or sets name for this Event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date for this Event.
        /// </summary>
        public DateTime? UtcDateStart { get; set; }

        /// <summary>
        /// Gets or sets the end date for this Event.
        /// </summary>
        public DateTime? UtcDateEnd { get; set; }

     
 
    }
}
