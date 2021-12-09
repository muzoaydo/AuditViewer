using Volo.Abp.Settings;

namespace AuditViewer.Settings
{
    public class AuditViewerSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AuditViewerSettings.MySetting1));
        }
    }
}
