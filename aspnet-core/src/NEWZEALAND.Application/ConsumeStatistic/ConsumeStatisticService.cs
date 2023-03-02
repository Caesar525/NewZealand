using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NEWZEALAND.ConsumeStatistic.Dto;
using NEWZEALAND.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.ConsumeStatistic
{
    [AbpAuthorize]
    public class ConsumeStatisticService : NEWZEALANDAppServiceBase, INEWZEALANDAppService<NZ_CONSUMEDto, long, NZ_CreateConsumeDto, NZ_CreateConsumeDto>
    {
        #region 依赖对象
        private readonly IRepository<NZ_CONSUME, long> _repository;
        #endregion
        #region 构造函数
        public ConsumeStatisticService(
            IRepository<NZ_CONSUME, long> repository
            )
        {
            _repository = repository;
        }
        #endregion
        #region 新增修改数据
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
            throw new NotImplementedException();
        }
        #endregion
        #region 分页查询
        public Task<PagedResultDto<NZ_CONSUMEDto>> GetAll(NZ_CreateConsumeDto input)
        {
            throw new NotImplementedException();
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
    }
}
