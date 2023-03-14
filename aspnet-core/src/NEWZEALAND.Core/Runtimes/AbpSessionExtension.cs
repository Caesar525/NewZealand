using Abp.Dependency;
using Abp.Runtime.Session;
using System.Linq;
using System.Security.Claims;

namespace NEWZEALAND.Runtimes
{
    public static class AbpSessionExtension
    {
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="abpSession"></param>
        /// <param name="principalAccessor"></param>
        /// <returns></returns>
        public static string GetUserName(this IAbpSession abpSession, IPrincipalAccessor principalAccessor = null)
        {
            if (principalAccessor == null)
            {
                principalAccessor = IocManager.Instance.Resolve<IPrincipalAccessor>();
            }
            return principalAccessor.Principal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)
                ?.Value;
        }
    }
}