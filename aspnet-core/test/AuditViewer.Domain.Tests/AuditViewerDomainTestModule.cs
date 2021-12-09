using AuditViewer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AuditViewer
{
    [DependsOn(
        typeof(AuditViewerEntityFrameworkCoreTestModule)
        )]
    public class AuditViewerDomainTestModule : AbpModule
    {

    }
}