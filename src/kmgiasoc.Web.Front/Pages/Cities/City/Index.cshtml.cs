using System.Threading.Tasks;

namespace kmgiasoc.Web.Pages.Cities.City
{
    public class IndexModel : kmgiasocPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
