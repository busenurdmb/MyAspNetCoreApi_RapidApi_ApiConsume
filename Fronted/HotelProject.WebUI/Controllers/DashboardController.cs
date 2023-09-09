using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class DashboardController : Controller
    {
     
        public IActionResult Index()
        {
         
                return View();
        }
    }
}
