using Abp.EntityHistory;
using AuditViewer.AuditLogActions;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.AuditLogs
{
    public class AuditLogDto : AuditedEntityDto<Guid>
    {
        public string ApplicationName { get; set; }

        public Guid? UserId { get; protected set; }

        public string UserName { get; protected set; }

        public Guid? TenantId { get; protected set; }

        public string TenantName { get; protected set; }

        public Guid? ImpersonatorUserId { get; protected set; }

        public Guid? ImpersonatorTenantId { get; protected set; }

        public DateTime ExecutionTime { get; protected set; }

        public int ExecutionDuration { get; protected set; }

        public string ClientIpAddress { get; protected set; }

        public string ClientName { get; protected set; }

        public string ClientId { get; set; }

        public string CorrelationId { get; set; }

        public string BrowserInfo { get; protected set; }

        public string HttpMethod { get; protected set; }

        public string Url { get; protected set; }

        public string Exceptions { get; protected set; }

        public string Comments { get; protected set; }

        public int? HttpStatusCode { get; set; }

        public virtual ICollection<EntityChange> EntityChanges { get; protected set; }

        public ICollection<AuditLogActionDto> AuditLogActions { get; protected set; }

    }
}