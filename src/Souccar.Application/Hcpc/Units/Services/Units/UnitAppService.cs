﻿using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Units.Services.Units
{
    public class UnitAppService :
        AsyncSouccarAppService<Unit, UnitDto, int, PagedUnitRequestDto, CreateUnitDto, UpdateUnitDto>, IUnitAppService
    {
        private readonly IUnitManager _unitDomainService;
        public UnitAppService(IUnitManager unitDomainService) : base(unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }

        public IList<UnitNameForDropdownDto> GetNameForDropdown()
        {
            return _unitDomainService.GetAll()
                .Select(x=>new UnitNameForDropdownDto(x.Id,x.Name)).ToList();
        }
    }
}
