using System.Threading.Tasks;
using Abp.Application.Services;
using NEWZEALAND.Authorization.Accounts.Dto;

namespace NEWZEALAND.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
