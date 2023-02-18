﻿using Abp.Domain.Entities;
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
    /// 总支出
    /// </summary>
    public class NZ_CONSUME: FullAuditedEntity<long>
    {
        /// <summary>
        /// 月份
        /// </summary>
        [Comment("月份")]
        public DateTime? MONTH { get; set; }
        /// <summary>
        /// 极值
        /// </summary>
        [Comment("极值")]
        public decimal? EXTREMUM { get; set; }
        /// <summary>
        /// 增值
        /// </summary>
        [Comment("增值")]
        public decimal? INCREMENT { get; set; }
        /// <summary>
        /// 最低保障值
        /// </summary>
        [Comment("最低保障值")]
        public decimal? LOWEST { get; set; }
        /// <summary>
        /// 可支配收入
        /// </summary>
        [Comment("可支配收入")]
        public decimal? DISPOSABLEINCOME { get; set;}
        /// <summary>
        /// 总收入
        /// </summary>
        [Comment("总收入")]
        public decimal? TOTALCONSUME { get; set; }
        /// <summary>
        /// 可支配结余
        /// </summary>
        [Comment("可支配结余")]
        public decimal? DISPOSABLEBALANCE { get; set; }
        
    }
}
