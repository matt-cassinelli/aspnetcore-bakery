using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Bakery.TagHelpers;

public class EmailTagHelper : TagHelper // By convention, the text before "TagHelper" is used as the tag.
{
    public string? Address { get; set; }
    public string? Content { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output) // By convention, this method gets invoked automatically when used.
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", "mailto:" + Address);
        output.Content.SetContent(Content);
    }

    //public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {}
}