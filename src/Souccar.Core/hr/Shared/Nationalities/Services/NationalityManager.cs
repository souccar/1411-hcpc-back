using Souccar.Core.Services;
using Abp.Domain.Repositories;
using Souccar.hr.Shared.Nationalities;

namespace Souccar.hr.Shared.Nationalities.Services
{
    public class NationalityManager : SouccarDomainService<Nationality, int>, INationalityManager
    {
        public NationalityManager(IRepository<Nationality, int> nationalityRepository) : base(nationalityRepository)
        {

        }
    }
}
