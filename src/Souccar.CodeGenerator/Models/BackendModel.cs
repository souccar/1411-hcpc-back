using System.ComponentModel.DataAnnotations;

namespace Souccar.CodeGenerator.Models
{
    public class BackendModel
    {
        [Required]
        public string ModuleName { get; set; }

        [Required]
        public GenerateType Type { get; set; }
    }

    public enum GenerateType
    {
        Services,
        Localization,
        Permissions,
        DbSet
    }
}
