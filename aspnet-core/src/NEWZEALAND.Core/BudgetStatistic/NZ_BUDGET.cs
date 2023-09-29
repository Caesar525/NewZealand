using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NEWZEALAND
{
    public class NZ_BUDGET : FullAuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
        /// <summary>
        /// 预算时间
        /// 制定预算的时间
        /// </summary>
        [Comment("预算时间")]
        public DateTime? BudgetDate { get; set; }

        /// <summary>
        /// 预算总量
        /// 多少预算
        /// </summary>
        [Comment("预算总量")]
        public decimal? AmountOfBudget { get; set; }

        /// <summary>
        /// 预算结余
        /// 还剩下多少钱
        /// </summary>
        [Comment("预算结余")]
        public decimal? BudgetSurplus { get; set; }

        /// <summary>
        /// 使用率
        /// 指每月最终预算总量的使用率
        /// </summary>
        [Comment("使用率")]
        public decimal? UsageRate { get; set; }

        /// <summary>
        /// 备注
        /// 提供特殊说明
        /// </summary>
        [Comment("备注")]
        public string Remark { get; set; }
    }
}
