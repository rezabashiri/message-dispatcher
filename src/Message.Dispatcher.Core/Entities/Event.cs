using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message.Dispatcher.Core.Common;
using Message.Dispatcher.Core.Enums;

namespace Message.Dispatcher.Core.Entities
{
    public class Event : BaseEntity
    {
        public Event()
        {
           
        }
        /// <summary>
        /// Gets or sets name for this Event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start date for this Event.
        /// </summary>
        public DateTime UtcDateStart { get; set; }

        /// <summary>
        /// Gets or sets the end date for this Event.
        /// </summary>
        public DateTime UtcDateEnd { get; set; }

        /// <summary>
        /// Gets or sets the ApiEventId for this Event.
        /// </summary>
        public int ApiEventId { get; set; }

        /// <summary>
        /// Gets or sets the Visibility for this Event.
        /// True is visible otherwise Hidden
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or Sets the type of event
        /// </summary>
        public EventType EventType { get; set; } = EventType.Unknown;

        /// <summary>
        /// Gets or Sets Event App key
        /// </summary>
        public string AppKey { get; set; }

    }
}
