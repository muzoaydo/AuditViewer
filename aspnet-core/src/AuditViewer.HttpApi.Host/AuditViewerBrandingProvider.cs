using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AuditViewer
{
    [Dependency(ReplaceServices = true)]
    public class AuditViewerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AuditViewer";
    }
}
