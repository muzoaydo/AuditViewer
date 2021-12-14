using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AuditViewer.AuditLogActions;
using AuditViewer.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AuditViewer.EntityFrameworkCore.AuditLogActions
{
    public class EfCoreAuditLogActionRepository
        : EfCoreRepository<AuditViewerDbContext, AuditLogAction, Guid>,
        IAuditLogActionRepository
    {
        public EfCoreAuditLogActionRepository(
            IDbContextProvider<AuditViewerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<long> GetCountAsync(GetAuditLogActionListDto input)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(auditLogAction => auditLogAction.AuditLogId == input.selectedLogId)
                .CountAsync();
        }

        public async Task<List<AuditLogAction>> GetListByIdAsync(GetAuditLogActionListDto input)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(auditLogAction => auditLogAction.AuditLogId == input.selectedLogId)
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();
        }

        
    }
}
