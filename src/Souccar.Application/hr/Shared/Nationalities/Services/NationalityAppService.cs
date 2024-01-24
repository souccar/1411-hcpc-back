using Souccar.hr.Shared.Nationalities.Dto;
using System.Collections.Generic;

namespace Souccar.hr.Shared.Nationalities.Services
{
    public class NationalityAppService : SouccarAppServiceBase, INationalityAppService
    {
        private readonly INationalityManager _nationalityManager;

        public NationalityAppService(INationalityManager nationalityManager)
        {
            _nationalityManager = nationalityManager;
        }

        public IList<NationalityDto> GetAll()
        {
            var nationalities = _nationalityManager.GetAll();
            return ObjectMapper.Map<List<NationalityDto>>(nationalities);
        }
    }
}
