using Abp.Auditing;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Domain
{
    [AutoMapFrom(typeof(AuditLog))]
    public class AuditLogs : AuditLog, IHasCreateUserName
    {
        public string CreateUserName { get; set; }
    }
}
