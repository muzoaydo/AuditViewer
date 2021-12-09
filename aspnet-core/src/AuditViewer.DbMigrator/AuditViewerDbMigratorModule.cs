using AuditViewer.EntityFrameworkCore;
using AuditViewer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AuditViewer.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AuditViewerEntityFrameworkCoreModule),
        typeof(AuditViewerApplicationContractsModule)
        )]
    public class AuditViewerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
