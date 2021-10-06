using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class AbpAspNetCoreMvcUiBasicThemeModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAspNetCoreMvcUiBasicThemeModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<BasicTheme>();

                if (options.DefaultThemeName == null)
                {
                    options.DefaultThemeName = BasicTheme.Name;
                }
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiBasicThemeModule>("Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic");
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeMainTopToolbarContributor());
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    //.Add(BasicThemeBundles.Styles.Global, bundle =>
                    .Add("MyGlobalBundle", bundle =>
                    {
                        bundle.AddFiles(
                        "/libs/vendors/ckeditor/styles.css",
                        "/libs/styles/index.css",
                        "/libs/@fortawesome/fontawesome-free/css/all.css"
                        );
                        //bundle
                        //    .AddBaseBundles(StandardBundles.Styles.Global)
                        //    .AddContributors(typeof(BasicThemeGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BasicThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                        .AddFiles(
                           "/libs/js/index.js",
                           "/libs/js/alpinejs/cdn.min.js"
                            )
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(BasicThemeGlobalScriptContributor));
                    });
            });
        }
    }
}
