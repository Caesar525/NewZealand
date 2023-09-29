using Abp.Application.Services.Dto;
using Abp.Authorization;
using NEWZEALAND.BudgetStatistic.Dto;
using NEWZEALAND.ConsumeStatistic.Dto;
using NEWZEALAND.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.BudgetStatistic
{
    [AbpAuthorize]
    public class BudgetAppService: NEWZEALANDAppServiceBase, INEWZEALANDAppService<NZ_BUDGETDto, long, NZ_CreateBudgetDto, NZ_CreateBudgetDto>
    {
        #region 接口实现方法
        public Task<long> CreateOrEdit(NZ_BUDGETDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<NZ_BUDGETDto>> GetAll(NZ_CreateBudgetDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<NZ_BUDGETDto>> GetAllNoPaged(NZ_CreateBudgetDto input)
        {
            throw new NotImplementedException();
        }

        public Task<NZ_BUDGETDto> GetEntityForEdit(long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 基本功能
        #endregion
    }
}
