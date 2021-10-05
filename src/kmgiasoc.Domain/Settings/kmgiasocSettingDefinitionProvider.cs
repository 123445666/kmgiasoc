using Volo.Abp.Settings;

namespace kmgiasoc.Settings
{
    public class kmgiasocSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(kmgiasocSettings.MySetting1));
        }
    }
}
