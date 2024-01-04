using Abp.Domain.Entities;

namespace Souccar.Core.PagesGenerator.Pages
{
    public class ToolbarCommand : Entity
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string ImageClass { get; set; }
        public string ClassName { get; set; }
        public bool Additional { get; set; }
        public string Handler { get; set; }
    }
}
