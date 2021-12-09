using System;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace AuditViewer.Filters
{
    public interface IAuditLogFilterRepository : IRepository<AuditLog, Guid>
    {
        //Task<List<AuditLog>> GetFilteredListAsync(FilterDto input);

        Task<long> GetCountAsync(FilterDto input);
    }
}
