using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND
{
    /// <summary>
    /// 消费物资维护周期明细
    /// </summary>
    public class NZ_MATERIALSLIST: FullAuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        [MaxLength(40)]
        [Comment("物品ID")]
        public string CODE { get; set; }
        /// <summary>
        /// 周期单位
        /// MONTH-月;YEAR-年;DAY-天;WEEK-周;QUARTER-季度
        /// </summary>
        [MaxLength(20)]
        [Comment("周期单位")]
        public string MAINTENANCEUNIT { get; set; }
        /// <summary>
        /// 本次周期内费用
        /// </summary>
        [Comment("本次周期内费用")]
        public decimal? SPENDING { get; set; }
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
    }
}
