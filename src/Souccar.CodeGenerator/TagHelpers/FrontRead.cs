using Microsoft.AspNetCore.Razor.TagHelpers;
using Souccar.hr.Personnel.Employees;
using System.Text;

namespace Souccar.CodeGenerator.TagHelpers
{
    public class FrontRead: TagHelper
    {
        public string EntityName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "FrontReadTagHelper"; 
            output.TagMode = TagMode.StartTagAndEndTag;
            
            var sb = new StringBuilder();
            sb.AppendFormat($"<span>Entity:</span> <strong>{EntityName}</strong><br/>");
            
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
