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
    /// 预算池
    /// </summary>
    public class NZ_BUDGETPOOL: FullAuditedEntity<long>
    {
        /// <summary>
        /// 周期单位
        /// MONTH-月;YEAR-年;DAY-天;WEEK-周;QUARTER-季度
        /// </summary>
        [MaxLength(20)]
        [Comment("周期单位")]
        public string MAINTENANCEUNIT { get; set; }
        /// <summary>
        /// 预算池
        /// </summary>
        [Comment("预算池")]
        public decimal? POOLMONEY { get; set; }
    }
}
