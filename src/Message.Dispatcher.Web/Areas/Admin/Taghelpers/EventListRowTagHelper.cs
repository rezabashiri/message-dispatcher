using System.Text;
using Message.Dispatcher.Messages.Event;
using Message.Dispatcher.Messages.Event.Responses;
using Message.Dispatcher.Share.Extensions;
using Message.Dispatcher.Web.Areas.Admin.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Message.Dispatcher.Web.Areas.Admin.Taghelpers;

public class EventListRowTagHelper : TagHelper
{

    /// <summary>
    /// An <see cref="IUrlHelper"/> implementation for generating URLs.
    /// </summary>
    private readonly IUrlHelper urlHelper;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventListRowTagHelper"/> class.
    /// Sets up the required resources for creating an Event List tr, based on the Event State.
    /// </summary>
    /// <param name="urlHelper">An <see cref="IUrlHelper"/> implementation for generating URLs.</param>
    public EventListRowTagHelper(IUrlHelper urlHelper)
    {
        this.urlHelper = urlHelper;
    }

    /// <summary>
    /// Gets or sets a value that allows access to the Event in scope
    /// for this particular instance of a the TagHelper.
    /// </summary>
    public EventListByAppKeyResponse EventData { get; set; }


    /// <summary>
    /// Overriden process method that amends the output of the tag provided to
    /// match the 'tr' structured designed for this Event List row.
    /// </summary>
    /// <param name="context">The current tag helper context.</param>
    /// <param name="output">The current output (to be manipulated within this type).</param>
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // 1) Switch out the provided 'event-list-row' element provided for a 'tr' tag (with the appropriate class/data-href definitions)
        this.ConfigureTableRow(output);

        // 2) Directly control the 'td' element output within this 'tr', based on the state of the Event
        output.Content.SetHtmlContent(this.GetEventRowLinkContent());
    }

    /// <summary>
    /// Private method that amends the output to a 'tr' element and sets attributes
    /// on this wrapping element based on the state of the Event in scope (like directly
    /// controlling the href address this Event navigates to on click in the target table).
    /// </summary>
    /// <param name="output">The current output to be amended.</param>
    private void ConfigureTableRow(TagHelperOutput output)
    {
        // The output is always a 'tr' element with a class of 'row-link' - these are targeted for click/navigation mechanics
        output.TagName = "tr";
        output.Attributes.SetAttribute("class", "row-link");

        // The data-href for a given 'tr' will depending on the EventImportStatus. Completed events = Event Dashboard, otherwise navigate to the Import controller
        string actionLinkHref = this.urlHelper.Page("Message.Dispatcher", new ToDispatcherDto { Name = this.EventData.Name, APIEventId = this.EventData.ApiEventId});
        output.Attributes.SetAttribute("data-href", actionLinkHref);

        output.TagMode = TagMode.StartTagAndEndTag;
    }

    /// <summary>
    /// Private method that generates the set of 'td' elements for the
    /// Event in scope, to return to the caller.
    /// </summary>
    /// <returns>A string representing the 'td' element structure for this wrapping 'tr'.</returns>
    private string GetEventRowLinkContent()
    {
        StringBuilder eventRowLinkHtmlContent = new StringBuilder();
        eventRowLinkHtmlContent.Append($"<td>{ this.EventData.Name }</td>");
        eventRowLinkHtmlContent.Append($"<td> { this.EventData.Type.GetDescription() }  </td>");

        return eventRowLinkHtmlContent.ToString();
    }
}