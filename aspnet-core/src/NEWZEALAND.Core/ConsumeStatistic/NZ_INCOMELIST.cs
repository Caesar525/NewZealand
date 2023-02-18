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
    /// 收入明细
    /// </summary>
    public class NZ_INCOMELIST: FullAuditedEntity<long>
    {
        /// <summary>
        /// 月份
        /// </summary>
        [Comment("月份")]
        public DateTime? MONTH { get; set; }
        /// <summary>
        /// 总收入
        /// </summary>
        [Comment("总收入")]
        public decimal? INCOME { get; set; }
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
    }
}
