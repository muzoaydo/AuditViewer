using System;
using Volo.Abp.Application.Dtos;

namespace AuditViewer.AuditLogActions
{
    public class GetAuditLogActionListDto : PagedAndSortedResultRequestDto
    {
        public Guid selectedLogId { get; set; }
    }
}