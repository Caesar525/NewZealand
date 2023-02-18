using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NEWZEALAND.Configuration.Dto;

namespace NEWZEALAND.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NEWZEALANDAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
