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
    /// 消费物资
    /// </summary>
    public class NZ_MATERIALS: FullAuditedEntity<long>
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        [MaxLength(40)]
        [Comment("物品ID")]
        public string CODE { get; set; }
        /// <summary>
        /// 物品
        /// </summary>
        [MaxLength(20)]
        [Comment("物品")]
        public string GOODS { get; set; }
        /// <summary>
        /// 标准价格
        /// </summary>
        [Comment("标准价格")]
        public decimal? STANDARDPRICE { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Comment("数量")]
        public decimal? NUMBER { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [MaxLength(20)]
        [Comment("单位")]
        public string UNIT { get; set; }
        /// <summary>
        /// 实际花销
        /// </summary>
        [Comment("实际花销")]
        public decimal? REALSPENDING { get; set; }
        /// <summary>
        /// 周期内总维护费用
        /// </summary>
        [Comment("周期内总维护费用")]
        public decimal? MAINTENANCESPENDING { get; set; }
        /// <summary>
        /// 物资类型
        /// 00-预计购买物资;01-已经购买物资;02-废弃创收物资
        /// </summary>
        [MaxLength(5)]
        [Comment("物资类型")]
        public string MATERIALSTYPE { get; set; }
    }
}
