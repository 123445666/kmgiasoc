using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace kmgiasoc.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<kmgiasocWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
