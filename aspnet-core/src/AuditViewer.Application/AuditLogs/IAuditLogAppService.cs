using AuditViewer.Filters;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AuditViewer.AuditLogs
{
    public interface IAuditLogAppService :
        IReadOnlyAppService<
            AuditLogDto,
            Guid,
            PagedAndSortedResultRequestDto
            >
    {
        Task<PagedResultDto<AuditLogDto>> GetFilteredListAsync(FilterDto input);
    }
}