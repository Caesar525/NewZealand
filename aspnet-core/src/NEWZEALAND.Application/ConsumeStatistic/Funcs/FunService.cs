using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using NEWZEALAND.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.ConsumeStatistic.Funcs
{
    public class FunService:DomainService
    {
        #region 依赖对象
        private readonly IRepository<NZ_CONSUMELIST, long> _repository;
        private readonly IRepository<NZ_CONSUME, long> _repositoryConsume;

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        #endregion

        #region 构造方法
        public FunService(
            IRepository<NZ_CONSUMELIST, long> repository,
            IRepository<NZ_CONSUME, long> repositoryConsume,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            _repository = repository;
            _repositoryConsume = repositoryConsume;
            _unitOfWorkManager = unitOfWorkManager;
        }
        #endregion

        #region 重新计算
        /// <summary>
        /// 重新计算
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>

        public async Task<bool> ReCalculation(DateTime month)
        {
            //获取上个月总消费统计
            var nzConsumeLastMonthList = await _repositoryConsume.GetAllListAsync(x => x.IsDeleted == false && x.CONSUMEMONTH!=null && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == ((month.Year * 12 + month.Month)) - 1);//获取上月的总消费统计
            //获取本月明细
            var nzConsumeThisMonthList = await _repositoryConsume.GetAllListAsync(x => x.IsDeleted == false && x.CONSUMEMONTH != null && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == (month.Year * 12 + month.Month));//获取本月的总消费统计
            //计算本月总额
            var nzConsumeList = await _repository.GetAllListAsync(x => x.IsDeleted == false && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == (month.Year * 12 + month.Month));
            //获取当前添加月份下一个月的数据
            var nzConsumeNextMonth = await _repositoryConsume.FirstOrDefaultAsync(x => x.CONSUMEMONTH.Value.Month == month.AddMonths(1).Month);//下个月的数据
            //校验存在当前月份明细
            //if (nzConsumeThisMonthList.Count <= 0)
            //{
            //    return false;
            //}
            var nzConsumeLastMonth = new NZ_CONSUME();
            if (nzConsumeLastMonthList.Count <= 0)
            {
                nzConsumeLastMonth = new NZ_CONSUME();
                nzConsumeLastMonth.EXTREMUM = 0;
                nzConsumeLastMonth.TOTALCONSUME = 0;
                nzConsumeLastMonth.INCREMENT = 0;
                nzConsumeLastMonth.LOWEST = 0;
                nzConsumeLastMonth.DISPOSABLEINCOME = 0;
                nzConsumeLastMonth.DISPOSABLEBALANCE = 0;
            }
            else
            {
                nzConsumeLastMonth = nzConsumeLastMonthList.FirstOrDefault();
            }
            //判断下月数据是否为null
            if (nzConsumeNextMonth == null)
            {
                nzConsumeNextMonth = new NZ_CONSUME();
                nzConsumeNextMonth.EXTREMUM = 0;
                nzConsumeNextMonth.TOTALCONSUME = 0;
                nzConsumeNextMonth.INCREMENT = 0;
                nzConsumeNextMonth.LOWEST = 0;
                nzConsumeNextMonth.DISPOSABLEINCOME = 0;
                nzConsumeNextMonth.DISPOSABLEBALANCE = 0;
            }
            
            var nzConsumeThisMonth = nzConsumeThisMonthList.Count > 0 ? nzConsumeThisMonthList.FirstOrDefault() : null;//获取本月的总消费统计
            if (nzConsumeThisMonth != null)
            {
                //计算本月消费总和
                var allConsume = nzConsumeList.Count > 0 ? nzConsumeList.Sum(x => x.CONSUME) : 0m;
                //处理新增
                //var entity = ObjectMapper.Map<NZ_CONSUMELIST>(input);
                //var result = await _repository.InsertAsync(entity);
                //更新统计
                nzConsumeThisMonth.DISPOSABLEINCOME = nzConsumeThisMonth.EXTREMUM + nzConsumeNextMonth.INCREMENT - nzConsumeNextMonth.LOWEST;//计算可支配收入：极值+增值-最低保障
                nzConsumeThisMonth.EXTREMUM = nzConsumeLastMonth.EXTREMUM + nzConsumeThisMonth.INCREMENT - nzConsumeLastMonth.TOTALCONSUME + nzConsumeLastMonth.DISPOSABLEBALANCE;//计算当前消费极值
                //更新总消费
                //nzConsumeThisMonth.TOTALCONSUME = nzConsumeThisMonth.TOTALCONSUME + input.CONSUME;//计算总消费
                var totalConsume = 0m;
                foreach (var item in nzConsumeList)
                {
                    totalConsume += item.CONSUME == null ? 0m : item.CONSUME.Value;
                    nzConsumeThisMonth.TOTALCONSUME = totalConsume;
                }
                nzConsumeThisMonth.DISPOSABLEBALANCE = nzConsumeThisMonth.DISPOSABLEINCOME - nzConsumeThisMonth.TOTALCONSUME;//计算可支配结余
                //更新本月数据
                await _repositoryConsume.UpdateAsync(nzConsumeThisMonth);
                //计算并更新下个月的最低保障数据
                nzConsumeNextMonth.LOWEST = nzConsumeNextMonth.LOWEST+nzConsumeThisMonth.DISPOSABLEBALANCE;
                await _repositoryConsume.UpdateAsync(nzConsumeNextMonth);
                return true;
            }
            else
            {
                nzConsumeThisMonth = new NZ_CONSUME();
                //如果不存在本月的统计数据，则直接统计并新增
                nzConsumeThisMonth.CONSUMEMONTH = month;
                nzConsumeThisMonth.INCREMENT = 7300m;
                //本月极值=上月极值+本月总增值-上月总消费+上月结余
                nzConsumeThisMonth.EXTREMUM = nzConsumeLastMonth.EXTREMUM + nzConsumeThisMonth.INCREMENT - nzConsumeLastMonth.TOTALCONSUME + nzConsumeLastMonth.DISPOSABLEBALANCE;//计算当前消费极值;
                //本月总消费计算
                var totalConsume = 0m;
                foreach (var item in nzConsumeList)
                {
                    totalConsume += item.CONSUME == null ? 0m : item.CONSUME.Value;
                    nzConsumeThisMonth.TOTALCONSUME = totalConsume;
                }
                //本月最低保障值
                nzConsumeThisMonth.LOWEST = 0;
                //可支配收入:本月极值+下个月增值-下个月最低保障值
                nzConsumeThisMonth.DISPOSABLEINCOME = nzConsumeThisMonth.EXTREMUM + nzConsumeNextMonth.INCREMENT - nzConsumeNextMonth.LOWEST;
                //计算可支配结余=本月可支配收入-本月总消费
                nzConsumeThisMonth.DISPOSABLEBALANCE = nzConsumeThisMonth.DISPOSABLEINCOME - nzConsumeThisMonth.TOTALCONSUME;

                //新增数据
                await _repositoryConsume.InsertAsync(nzConsumeThisMonth);
                //计算并更新下个月的最低保障数据
                nzConsumeNextMonth.LOWEST = nzConsumeNextMonth.LOWEST + nzConsumeThisMonth.DISPOSABLEBALANCE;
                nzConsumeNextMonth.CONSUMEMONTH = month.AddMonths(1);
                await _repositoryConsume.InsertAsync(nzConsumeNextMonth);

                return true;
            }
            return true;
        }
        #endregion
    }
}
