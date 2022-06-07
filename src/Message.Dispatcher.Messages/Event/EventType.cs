using System.ComponentModel;

namespace Message.Dispatcher.Messages.Event;

public enum EventType
{
    [Description("")]
    Unknown = 0,

    [Description("Conference")]
    Conference = 1,

    [Description("Greeting Event")]
    Greeting = 2
}