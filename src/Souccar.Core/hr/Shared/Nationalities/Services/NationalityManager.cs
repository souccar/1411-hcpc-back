using Abp.Domain.Repositories;
using Souccar.hr.Shared.Nationalities;
using Souccar.Core.Services.Implements;

namespace Souccar.hr.Shared.Nationalities.Services
{
    public class NationalityManager : SouccarDomainService<Nationality, int>, INationalityManager
    {
        public NationalityManager(IRepository<Nationality, int> nationalityRepository) : base(nationalityRepository)
        {

        }
    }
}
