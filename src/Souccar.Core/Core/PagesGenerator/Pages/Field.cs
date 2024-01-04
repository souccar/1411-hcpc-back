using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Souccar.Core.PagesGenerator.Pages
{
    public class Field : Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool Editable { get; set; }
        public object DefaultValue { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanInsert { get; set; }

        public IDictionary<string, IDictionary<string, object>> ValidationRules { get; set; }

        public int Order { get; set; }
        public int Width { get; set; }
        public bool Hidden { get; set; }
        public string Title { get; set; }
        public string FieldName { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }
        public bool IsRequired { get; set; }
        public bool IsFile { get; set; }
        public bool IsDateTime { get; set; }
        public bool IsTime { get; set; }
        public string FileAcceptExtension { get; set; }
        public int FileSize { get; set; }
    }
}
