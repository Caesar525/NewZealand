using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NEWZEALAND.Excel.Dto
{
    public class AliPayImprotExcelDto
    {
        /// <summary>
        /// 交易时间
        /// </summary>
        [ImporterHeader(Name = "交易时间")]
        public string PayTime { get; set; }

        /// <summary>
        /// 交易分类
        /// </summary>
        [ImporterHeader(Name = "交易分类")]
        public string PayType { get; set; }

        /// <summary>
        /// 交易对方
        /// </summary>
        [ImporterHeader(Name = "交易对方")]
        public string PayOpposite { get; set; }

        /// <summary>
        /// 对方账号
        /// </summary>
        [ImporterHeader(Name = "对方账号")]
        public string PayOppositeAccount { get; set; }

        /// <summary>
        /// 商品说明
        /// </summary>
        [ImporterHeader(Name = "商品说明")]
        public string PayDeclare { get; set; }

        /// <summary>
        /// 收/支
        /// </summary>
        [ImporterHeader(Name = "收/支")]
        public string PayAndReceive { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [ImporterHeader(Name = "金额")]
        public decimal? PayMoney { get; set; }

        /// <summary>
        /// 收/付款方式
        /// </summary>
        [ImporterHeader(Name = "收/付款方式")]
        public string PayWay { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        [ImporterHeader(Name = "交易状态")]
        public string PayStatus { get; set; }

        /// <summary>
        /// 交易订单号
        /// </summary>
        [ImporterHeader(Name = "交易订单号")]
        public string PayOrderNumber { get; set; }

        /// <summary>
        /// 商家订单号
        /// </summary>
        [ImporterHeader(Name = "商家订单号")]
        public string PayVendor { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ImporterHeader(Name = "备注")]
        public string PayRemark { get; set; }
    }
}
