using System.Threading.Tasks;
using Abp.Application.Services;
using NEWZEALAND.Sessions.Dto;

namespace NEWZEALAND.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
