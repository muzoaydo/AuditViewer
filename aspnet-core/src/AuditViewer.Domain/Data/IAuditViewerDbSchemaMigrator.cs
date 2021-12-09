using System.Threading.Tasks;

namespace AuditViewer.Data
{
    public interface IAuditViewerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
