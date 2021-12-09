using Volo.Abp.Modularity;

namespace AuditViewer
{
    [DependsOn(
        typeof(AuditViewerApplicationModule),
        typeof(AuditViewerDomainTestModule)
        )]
    public class AuditViewerApplicationTestModule : AbpModule
    {

    }
}