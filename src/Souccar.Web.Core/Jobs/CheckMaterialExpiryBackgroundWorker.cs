using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using Souccar.Authorization.Users;
using Souccar.Hcpc.Materials.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Jobs
{
    public class CheckMaterialExpiryBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IMaterialAppService _materialAppService;

        public CheckMaterialExpiryBackgroundWorker(AbpAsyncTimer timer, IMaterialAppService materialAppService)
            : base(timer)
        {
            _materialAppService = materialAppService;
            Timer.Period = 5000; //5 seconds (good for tests, but normally will be more)
        }

        protected override async Task DoWorkAsync()
        {
            var materials = await _materialAppService.GetAsync(new EntityDto<int>() { Id = 1});
            if(materials == null)
            {
                Logger.Error("There is no material named Silicone");
            }

            Logger.Info("Material is exist");
        }
    }
}
