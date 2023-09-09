using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
