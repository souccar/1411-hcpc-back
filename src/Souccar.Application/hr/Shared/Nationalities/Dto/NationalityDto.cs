using Abp.Application.Services.Dto;

namespace Souccar.hr.Shared.Nationalities.Dto
{
    public class NationalityDto: EntityDto<int>
    {
        public string Name { get; set; }
    }
}
