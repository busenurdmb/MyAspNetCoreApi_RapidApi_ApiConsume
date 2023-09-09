using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadPartial : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
