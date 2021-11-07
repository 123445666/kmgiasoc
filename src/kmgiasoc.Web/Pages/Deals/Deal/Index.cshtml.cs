using System.Threading.Tasks;

namespace kmgiasoc.Web.Pages.Deals.Deal
{
    public class IndexModel : kmgiasocPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
