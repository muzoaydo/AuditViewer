using Abp.EntityHistory;
using AuditViewer.AuditLogActions;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.AuditLogActions
{
    public class GetAuditLogActionListDto : PagedAndSortedResultRequestDto
    {
        public Guid AuditLogId { get; set; }
    }
}