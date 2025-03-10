using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class HomeController : Controller
    {

        // ANA SAYFA YÖNLENDİRMESİ EKLENDİ
        public IActionResult Index()
        {
            return View();
        }
               public IActionResult About()
        {
            return View();
        }

    }
}
