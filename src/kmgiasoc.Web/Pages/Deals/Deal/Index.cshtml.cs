using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    [Authorize]
    public class IndexModel : kmgiasocPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
