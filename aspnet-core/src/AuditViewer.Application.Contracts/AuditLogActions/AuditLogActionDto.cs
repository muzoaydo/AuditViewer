using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace AuditViewer.AuditLogActions
{
    public class AuditLogActionDto : EntityDto<Guid>
    {
        public Guid? TenantId { get; protected set; }

        public Guid AuditLogId { get; protected set; }

        public string ServiceName { get; protected set; }

        public string MethodName { get; protected set; }

        public string Parameters { get; protected set; }

        public DateTime ExecutionTime { get; protected set; }

        public int ExecutionDuration { get; protected set; }

        public ExtraPropertyDictionary ExtraProperties { get; protected set; }

        public string ExtraProperty { get; set; }
    }
}
