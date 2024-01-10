using System.Collections.Generic;

namespace Souccar.Core.Filter
{
    public class FilterInputDto
    {
        public FilterInputDto()
        {
            Rules = new List<FilterInputItemDto>();
        }
        public string Condition { get; set; }

        public IList<FilterInputItemDto> Rules { get; set; }
    }
}
