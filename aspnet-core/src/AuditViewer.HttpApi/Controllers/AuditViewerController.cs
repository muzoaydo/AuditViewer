using AuditViewer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AuditViewer.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AuditViewerController : AbpController
    {
        protected AuditViewerController()
        {
            LocalizationResource = typeof(AuditViewerResource);
        }
    }
}