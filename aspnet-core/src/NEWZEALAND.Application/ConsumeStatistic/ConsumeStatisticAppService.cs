using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Dapper;
using NEWZEALAND.ConsumeStatistic.Dto;
using NEWZEALAND.Dapper;
using NEWZEALAND.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NEWZEALAND.ConsumeStatistic
{
    [AbpAuthorize]
    public class ConsumeStatisticAppService : NEWZEALANDAppServiceBase, INEWZEALANDAppService<NZ_CONSUMEDto, long, NZ_CreateConsumeDto, NZ_CreateConsumeDto>
    {
        #region 依赖对象
        private readonly IRepository<NZ_CONSUME, long> _repository;
        private readonly IDzhDapperRepository<NZ_CONSUME, long> _dzhDapperRepository;
        #endregion
        #region 构造函数
        public ConsumeStatisticAppService(
            IRepository<NZ_CONSUME, long> repository,
            IDzhDapperRepository<NZ_CONSUME, long> dzhDapperRepository
            )
        {
            _repository = repository;
            _dzhDapperRepository = dzhDapperRepository;
        }
        #endregion
        #region 新增修改数据
        [AbpAuthorize]
        public async Task<long> CreateOrEdit(NZ_CONSUMEDto input)
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
            //throw new NotImplementedException();
            return null;
        }
        #endregion
        #region 分页查询
        /// <summary>
        /// 分页查询
        /// 不能用系统事务，不知道是因为使用连接查询的问题还是因为使用了MySql的问题
        /// 同时query.ReadFirstOrDefaultAsync也会抛异常，不知道什么原因
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork(false)]
        [AbpAuthorize]
        public async Task<PagedResultDto<NZ_CONSUMEDto>> GetAll(NZ_CreateConsumeDto input)
        {
            //throw new NotImplementedException();
            //var filtered = _repository.GetAll()
            //    .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
            //;

            //var query = (from o in filtered.OrderBy(input.Sorting ?? "Id asc")
            //             select ObjectMapper.Map<ET_EMPTYDto>(o)
            //            );

            //var totalCount = await query.CountAsync();

            //var result = await query
            //    .PageBy(input)
            //    .ToListAsync();
            //return new PagedResultDto<NZ_CONSUMEDto>(
            //    totalCount,
            //    result
            //);
            var sql = $@"select * from NZ_CONSUME order by CONSUMEMONTH asc limit @SkipCount,@MaxResultCount";
            var query = await _dzhDapperRepository.Connection.QueryMultipleAsync(sql, new
            {
                input.SkipCount,
                input.MaxResultCount
            });
            var list = await query.ReadAsync<NZ_CONSUMEDto>();
            var count = (await _repository.GetAllListAsync()).Count;
            return new PagedResultDto<NZ_CONSUMEDto>(count, list.ToList());
        }
        #endregion
        #region 不分页查询
        public Task<ListResultDto<NZ_CONSUMEDto>> GetAllNoPaged(NZ_CreateConsumeDto input)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 查询指定id数据
        public Task<NZ_CONSUMEDto> GetEntityForEdit(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 新增数据
        private async Task<long> Create(NZ_CONSUMEDto input)
        {
            var entity = ObjectMapper.Map<NZ_CONSUME>(input);

            if (AbpSession.TenantId != null)
            {
                entity.TenantId = (int?)AbpSession.TenantId;
            }

            var result = await _repository.InsertAsync(entity);

            return 0;
        }
        #endregion
        #region 修改数据
        private async Task<long> Update(NZ_CONSUMEDto input)
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
            //var aaa=await _repositoryConsume.GetAsync(10);
            var bbb = _repository.FirstOrDefault(x => x.Id == 10);
            //var nzConSumeList = await _dzhDapperRepository.GetAllAsync(x=>x.CONSUME!=0);

            var nzConsumeListSql = "select * from NZ_CONSUME";
            var nzConsumeListQuery = await _dzhDapperRepository.QueryAsync<NZ_CONSUME>(nzConsumeListSql);
            return false;
        }
    }
}
