using Abp.Application.Services;
using Souccar.hr.Shared.Nationalities.Dto;
using System.Collections.Generic;

namespace Souccar.hr.Shared.Nationalities.Services
{
    public interface INationalityAppService: IApplicationService
    {
        IList<NationalityDto> GetAll();
    }
}
