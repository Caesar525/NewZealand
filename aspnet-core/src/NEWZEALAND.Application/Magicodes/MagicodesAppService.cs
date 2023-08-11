using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using NEWZEALAND.Magicodes.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.IE.Excel.Abp;
using NEWZEALAND.ConsumeStatistic.Dto;
using NEWZEALAND.Interface;
using Abp.Application.Services.Dto;

namespace NEWZEALAND.Magicodes
{
    public class MagicodesAppService : NEWZEALANDAppServiceBase, INEWZEALANDAppService<NZ_CONSUMELISTDto, long, NZ_CreateCONSUMELISTDto, NZ_CreateCONSUMELISTDto>
    {
        public Task<long> CreateOrEdit(NZ_CONSUMELISTDto input)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<NZ_CONSUMELISTDto>> GetAll(NZ_CreateCONSUMELISTDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<NZ_CONSUMELISTDto>> GetAllNoPaged(NZ_CreateCONSUMELISTDto input)
        {
            throw new NotImplementedException();
        }

        public Task<NZ_CONSUMELISTDto> GetEntityForEdit(long id)
        {
            throw new NotImplementedException();
        }
    }
}
