using Abp.Application.Services.Dto;
using Abp.Authorization;
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
        public Task<long> CreateOrEdit(NZ_CONSUMEDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<NZ_CONSUMEDto>> GetAll(NZ_CreateConsumeDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<NZ_CONSUMEDto>> GetAllNoPaged(NZ_CreateConsumeDto input)
        {
            throw new NotImplementedException();
        }

        public Task<NZ_CONSUMEDto> GetEntityForEdit(long id)
        {
            throw new NotImplementedException();
        }
    }
}
