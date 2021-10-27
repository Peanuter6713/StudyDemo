using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplicationDemo.Utils.RazorExtension
{
    [HtmlTargetElement("Hello")]
    public class CustomTagHelper : TagHelper
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int id = Id;
            string name = Name;

            output.TagName = "div";
            output.Attributes.Add("dir", "123");
            output.Attributes.Add("name", "teacher");
            output.PreContent.SetContent("Welcome to here...");
        }
    }
}
