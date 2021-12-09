using AuditViewer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AuditViewer.Permissions
{
    public class AuditViewerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AuditViewerPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(AuditViewerPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AuditViewerResource>(name);
        }
    }
}
