using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AuditViewer.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.AuditViewer.EntityFrameworkCore
{
    public class EntityFrameworkCoreAuditViewerDbSchemaMigrator
        : IAuditViewerDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAuditViewerDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AuditViewerDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AuditViewerDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
