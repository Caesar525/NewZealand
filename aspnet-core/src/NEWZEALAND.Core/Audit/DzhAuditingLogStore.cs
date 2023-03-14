using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Castle.Core.Logging;
using NEWZEALAND.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Audit
{
    public class DzhAuditingLogStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepository<AuditLogs, long> _auditlogRepository;
        private readonly IObjectMapper _objectMapper;
        public DzhAuditingLogStore(IRepository<AuditLogs, long> auditlogRepository, IObjectMapper objectMapper)
        {
            _auditlogRepository = auditlogRepository;
            _objectMapper = objectMapper;
        }

        public ILogger Logger { get; set; }

        public void Save(AuditInfo auditInfo)
        {
            var entity = _objectMapper.Map<AuditLogs>(AuditLog.CreateFromAuditInfo(auditInfo));//.MapTo<AuditLogs>();
            _auditlogRepository.Insert(entity);
        }

        public async Task SaveAsync(AuditInfo auditInfo)
        {
            var entity = _objectMapper.Map<AuditLogs>(AuditLog.CreateFromAuditInfo(auditInfo));//.MapTo<AuditLogs>();
            await _auditlogRepository.InsertAsync(entity);
        }
    }
}
