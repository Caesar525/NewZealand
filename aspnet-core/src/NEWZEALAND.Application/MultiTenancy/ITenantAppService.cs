using Abp.Application.Services;
using NEWZEALAND.MultiTenancy.Dto;

namespace NEWZEALAND.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

