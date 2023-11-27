﻿using Abp.Application.Services.Dto;
using Souccar.Core.Includes;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class PagedDailyProductionRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}