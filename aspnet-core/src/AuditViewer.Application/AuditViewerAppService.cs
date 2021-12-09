using System;
using System.Collections.Generic;
using System.Text;
using AuditViewer.Localization;
using Volo.Abp.Application.Services;

namespace AuditViewer
{
    /* Inherit your application services from this class.
     */
    public abstract class AuditViewerAppService : ApplicationService
    {
        protected AuditViewerAppService()
        {
            LocalizationResource = typeof(AuditViewerResource);
        }
    }
}
