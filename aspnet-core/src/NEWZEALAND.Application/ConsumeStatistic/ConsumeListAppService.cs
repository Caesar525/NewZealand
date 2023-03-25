using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Dapper;
using NEWZEALAND.ConsumeStatistic.Dto;
using NEWZEALAND.Dapper;
using NEWZEALAND.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.ConsumeStatistic
{
    public class ConsumeListAppService : NEWZEALANDAppServiceBase, INEWZEALANDAppService<NZ_CONSUMELISTDto, long, NZ_CreateCONSUMELISTDto, NZ_CreateCONSUMELISTDto>
    {
        #region 依赖对象
        private readonly IRepository<NZ_CONSUMELIST, long> _repository;
        private readonly IRepository<NZ_CONSUME, long> _repositoryConsume;
        private readonly IDzhDapperRepository<NZ_CONSUMELIST, long> _dzhDapperRepository;
        private readonly IDzhDapperRepository<NZ_CONSUME, long> _dzhDapperRepositoryConsume;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        #endregion
        #region 构造函数
        public ConsumeListAppService(
            IRepository<NZ_CONSUMELIST, long> repository,
            IRepository<NZ_CONSUME, long> repositoryConsume,
            IDzhDapperRepository<NZ_CONSUMELIST, long> dzhDapperRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IDzhDapperRepository<NZ_CONSUME, long> dzhDapperRepositoryConsume
            )
        {
            _repository = repository;
            _repositoryConsume = repositoryConsume;
            _dzhDapperRepository = dzhDapperRepository;
            _dzhDapperRepositoryConsume = dzhDapperRepositoryConsume;
            _unitOfWorkManager = unitOfWorkManager;
        }
        #endregion
        #region 新增修改数据
        public async Task<long> CreateOrEdit(NZ_CONSUMELISTDto input)
        {
            if (input.Id == 0)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }

        }
        #endregion
        #region 删除数据
        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 分页查询
        [UnitOfWork(false)]
        [AbpAuthorize]
        public async Task<PagedResultDto<NZ_CONSUMELISTDto>> GetAll(NZ_CreateCONSUMELISTDto input)
        {
            var sql = $@"select * from NZ_CONSUMELIST order by id desc limit @SkipCount,@MaxResultCount";
            var query = await _dzhDapperRepository.Connection.QueryMultipleAsync(sql, new
            {
                input.SkipCount,
                input.MaxResultCount
            });
            var list = await query.ReadAsync<NZ_CONSUMELISTDto>();
            var count = (await _repository.GetAllListAsync()).Count;
            return new PagedResultDto<NZ_CONSUMELISTDto>(count, list.ToList());
        }
        #endregion
        #region 不分页查询
        public Task<ListResultDto<NZ_CONSUMELISTDto>> GetAllNoPaged(NZ_CreateCONSUMELISTDto input)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 查询指定id数据
        public Task<NZ_CONSUMELISTDto> GetEntityForEdit(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 新增数据
        [AbpAuthorize]
        private async Task<long> Create(NZ_CONSUMELISTDto input)
        {
            //using (var unitOfWork = _unitOfWorkManager.Begin(System.Transactions.TransactionScopeOption.RequiresNew))
            //{
            //    var month = (DateTime)input.CONSUMEMONTH;
            //    var nzConSumeList = _dzhDapperRepository.GetAllAsync();

            //    var nzConsumeListSql = "select * from nz_consumelist";
            //    var nzConsumeListQuery = _dzhDapperRepository.Query<NZ_CONSUMELIST>(nzConsumeListSql);
            //    await unitOfWork.CompleteAsync();
            //}
            var month = (DateTime)input.CONSUMEMONTH;
            //获取上个月总消费统计
            var nzConsumeLastMonthList = await _repositoryConsume.GetAllListAsync(x => x.IsDeleted == false && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == ((month.Year * 12 + month.Month))-1);//获取上月的总消费统计
            //获取本月总消费统计
            var nzConsumeThisMonthList = await _repositoryConsume.GetAllListAsync(x => x.IsDeleted == false && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == (month.Year * 12 + month.Month));//获取本月的总消费统计
            //获取本月明细
            var nzConsumeList = await _repository.GetAllListAsync(x => x.IsDeleted == false && (((DateTime)x.CONSUMEMONTH).Year * 12 + ((DateTime)x.CONSUMEMONTH).Month) == (month.Year * 12 + month.Month));
            //获取当前添加月份下一个月的数据
            var nzConsumeNextMonth = await _repositoryConsume.FirstOrDefaultAsync(x => x.CONSUMEMONTH.Value.Month == input.CONSUMEMONTH.Value.AddMonths(1).Month);//下个月的数据
            //校验存在当前月份
            if (nzConsumeThisMonthList.Count <= 0)
            {
                return -1;
            }
            var nzConsumeLastMonth = new NZ_CONSUME();
            if (nzConsumeLastMonthList.Count<=0)
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
                nzConsumeLastMonth= nzConsumeLastMonthList.FirstOrDefault();
            }
            //var nzConsumeListThisMonth= nzConsumeList.FirstOrDefault();
            var nzConsumeThisMonth= nzConsumeThisMonthList.Count > 0 ? nzConsumeThisMonthList.FirstOrDefault() : null;//获取本月的总消费统计
            if (nzConsumeThisMonth != null)
            {
                //计算本月消费总和
                var allConsume = nzConsumeList.Count > 0 ? nzConsumeList.Sum(x => x.CONSUME) : 0m;
                //处理新增
                var entity = ObjectMapper.Map<NZ_CONSUMELIST>(input);
                var result = await _repository.InsertAsync(entity);
                //更新统计
                nzConsumeThisMonth.DISPOSABLEINCOME = nzConsumeThisMonth.EXTREMUM + nzConsumeNextMonth.INCREMENT - nzConsumeNextMonth.LOWEST;//计算可支配收入：极值+增值-最低保障
                nzConsumeThisMonth.EXTREMUM = nzConsumeLastMonth.EXTREMUM + nzConsumeThisMonth.INCREMENT - nzConsumeLastMonth.TOTALCONSUME+nzConsumeLastMonth.DISPOSABLEBALANCE;//计算当前消费极值
                nzConsumeThisMonth.TOTALCONSUME = nzConsumeThisMonth.TOTALCONSUME + input.CONSUME;//计算总消费
                nzConsumeThisMonth.DISPOSABLEBALANCE = nzConsumeThisMonth.DISPOSABLEINCOME - nzConsumeThisMonth.TOTALCONSUME;//计算可支配结余
                //更新
                await _repositoryConsume.UpdateAsync(nzConsumeThisMonth);

                return result.Id;
            }
            else
            {
                return -1;
            }
            return -1;
            
        }
        #endregion
        #region 修改数据
        private async Task<long> Update(NZ_CONSUMELISTDto input)
        {
            var detail = await _repository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, detail);
            return input.Id;
        }
        #endregion
        [UnitOfWork(false)]
        [AbpAuthorize]
        public async Task<bool> TestQuery()
        {
            var aaa=await _repositoryConsume.GetAllListAsync(x=>x.IsDeleted==false);
           var bbb =_repositoryConsume.FirstOrDefault(x => x.Id == 1);

            var nzConsumeListSql = "select * from nz_consumelist";
            var nzConsumeListQuery =await _dzhDapperRepository.QueryAsync<NZ_CONSUMELIST>(nzConsumeListSql);
            return false;
        }
    }
}
