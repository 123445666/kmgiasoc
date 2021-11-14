using kmgiasoc.Deals;
using kmgiasoc.Permissions;
using System.Collections.Generic;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.CmsKit;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.MediaDescriptors;
using Volo.CmsKit.Tags;

namespace kmgiasoc.Front
{
    [DependsOn(
        typeof(kmgiasocDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(kmgiasocApplicationContractsModule),
        typeof(kmgiasocFrontApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]
    public class kmgiasocFrontApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureTagOptions();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<kmgiasocFrontApplicationModule>();

            });
        }

        private void ConfigureTagOptions()
        {
            if (GlobalFeatureManager.Instance.IsEnabled<MediaFeature>())
            {
                Configure<CmsKitMediaOptions>(options =>
                {
                    if (GlobalFeatureManager.Instance.IsEnabled<BlogsFeature>())
                    {
                        options.EntityTypes.AddIfNotContains(
                            new MediaDescriptorDefinition(
                                DealConsts.EntityType,
                                createPolicies: new[]
                                {
                                        kmgiasocPermissions.Deal.Create,
                                        kmgiasocPermissions.Deal.Update
                                },
                                deletePolicies: new[]
                                {
                                        kmgiasocPermissions.Deal.Create,
                                        kmgiasocPermissions.Deal.Update,
                                        kmgiasocPermissions.Deal.Delete
                                }));
                    }
                });
            }
        }
    }
}
