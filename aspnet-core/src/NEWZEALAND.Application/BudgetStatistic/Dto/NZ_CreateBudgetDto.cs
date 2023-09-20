using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.BudgetStatistic.Dto
{
    public class NZ_CreateBudgetDto: PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
    }
}
