using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.BudgetStatistic.Dto
{
    [AutoMap(typeof(NZ_BUDGET))]
    public class NZ_BUDGETDto : FullAuditedEntityDto<long>
    {
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
    }
}
