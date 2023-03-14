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
    /// 支出明细
    /// </summary>
    public class NZ_CONSUMELIST : FullAuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// 月份
        /// </summary>
        [Comment("月份")]
        public DateTime? CONSUMEMONTH { get; set; }
        /// <summary>
        /// 总消费
        /// </summary>
        [Comment("总消费")]
        public decimal? CONSUME { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        [MaxLength(300)]
        [Comment("用途")]
        public string USAGE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        public string REMARK { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        [MaxLength(300)]
        [Comment("地点")]
        public string LOCATION { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        [Comment("发生时间")]
        public DateTime? HAPPENTIME { get; set; }
        /// <summary>
        /// 租户
        /// </summary>
        public int? TenantId { get; set; }
    }
}
