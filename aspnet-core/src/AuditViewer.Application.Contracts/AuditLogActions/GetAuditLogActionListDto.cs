using System;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.AuditLogActions
{
    public class GetAuditLogActionListDto : PagedAndSortedResultRequestDto
    {
        public Guid AuditLogId { get; set; }
    }
}