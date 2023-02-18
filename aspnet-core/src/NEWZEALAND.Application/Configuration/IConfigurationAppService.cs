using System.Threading.Tasks;
using NEWZEALAND.Configuration.Dto;

namespace NEWZEALAND.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
