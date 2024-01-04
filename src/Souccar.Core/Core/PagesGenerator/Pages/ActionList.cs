using Abp.Domain.Entities;

namespace Souccar.Core.PagesGenerator.Pages
{
    public class ActionList : Entity
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public bool ShowCommand { get; set; }
        public string HandlerName { get; set; }
        public string StyleClass { get; set; }
        public string ImageClass { get; set; }
    }
}
