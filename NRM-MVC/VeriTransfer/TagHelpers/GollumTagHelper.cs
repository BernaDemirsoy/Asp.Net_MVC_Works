using Microsoft.AspNetCore.Razor.TagHelpers;

namespace VeriTransfer.TagHelpers
{
    public class GollumTagHelper : TagHelper
    {
        public string GoTo { get; set; }
        public string Display { get; set; }
        public bool IsBold { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", GoTo);
            output.Attributes.Add("style", "color:blue");

            if (IsBold)
            {
                output.Content.AppendHtml("<strong>");
                output.Content.Append(Display);
                output.Content.AppendHtml("</strong>");
            }
            else output.Content.Append(Display);
        }
    }
}
