using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Souccar.Core.PagesGenerator.Pages
{
    public class Page : AggregateRoot
    {
        public Page()
        {
            Fields = new List<Field>();
            ActionsList = new List<ActionList>();
            ToolbarCommands = new List<ToolbarCommand>();
        }

        public string Name { get; set; }
        public IList<Field> Fields { get; set; }
        public IList<ActionList> ActionsList { get; set; }
        public IList<ToolbarCommand> ToolbarCommands { get; set; }
    }
}
