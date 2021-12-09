

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace AuditViewer.AuditLogActions
{
    public interface IAuditLogActionRepository : IRepository<AuditLogAction, Guid>
    {
        Task<List<AuditLogAction>> GetListByIdAsync(GetAuditLogActionListDto input);
        
        Task<long> GetCountAsync(GetAuditLogActionListDto input);
        
    }
}
