using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AuditViewer.Data
{
    /* This is used if database provider does't define
     * IAuditViewerDbSchemaMigrator implementation.
     */
    public class NullAuditViewerDbSchemaMigrator : IAuditViewerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}