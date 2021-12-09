using AuditViewer.AuditLogActions;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AuditViewer.AuditLogs
{
    public interface IAuditLogActionAppService :
        IReadOnlyAppService< //Defines CRUD methods
            AuditLogActionDto, //Used to show books
            Guid, //Primary key of the audit entity
            PagedAndSortedResultRequestDto //Used for paging/sorting
            > //Used to create/update a book
    {
        Task<PagedResultDto<AuditLogActionDto>> GetListByIdAsync(GetAuditLogActionListDto input);
    }
}
