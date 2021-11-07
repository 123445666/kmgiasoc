using System.Threading.Tasks;

namespace kmgiasoc.Web.Pages.Countries.Country
{
    public class IndexModel : kmgiasocPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
