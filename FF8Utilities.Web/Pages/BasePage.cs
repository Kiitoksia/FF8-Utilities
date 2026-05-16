using FF8Utilities.Web.Services;
using Microsoft.AspNetCore.Components;

namespace FF8Utilities.Web.Pages
{
    public abstract class BasePage : ComponentBase
    {
        [Inject]
        protected WebService WebService { get; set; }

        public abstract string PageTitle { get; }

        protected override void OnInitialized()
        {
            WebService.SetTitle(PageTitle);
        }
    }
}
