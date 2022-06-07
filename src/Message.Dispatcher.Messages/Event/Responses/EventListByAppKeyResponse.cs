using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Message.Dispatcher.Messages.Event.Responses;

public class EventListByAppKeyResponse
{

    /// <summary>
    /// Gets or sets the ApiEventId for this Event.
    /// </summary>
    public int ApiEventId { get; set; }

    /// <summary>
    /// Gets or sets name for this Event.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the start date for this Event.
    /// </summary>
    public DateTime DateStart { get; set; }

    /// <summary>
    /// Gets or sets the end date for this Event.
    /// </summary>
    public DateTime DateEnd { get; set; }

    /// <summary>
    /// Gets or sets the Type for the Event (e.g. Buyer/Supplier or Any2Any).
    /// </summary>
    public EventType Type { get; set; }

    /// <summary>
    /// Gets or Sets Visibility of event
    /// </summary>
    public bool Visible { get; set; }
 
}