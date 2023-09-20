using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND
{
    public class NZ_BUDGET : FullAuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
    }
}
