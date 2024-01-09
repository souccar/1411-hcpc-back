using System.ComponentModel.DataAnnotations;

namespace Souccar.CodeGenerator.Models
{
    public class FrontendModel
    {
        [Required]
        public string ModuleName { get; set; }

        [Required]
        public string Entity { get; set; }

        [Required]
        public FrontPage Page { get; set; }
    }

    public enum FrontPage
    {
        Read,
        Create,
        Edit,
        View,
        Filter
    }
}
