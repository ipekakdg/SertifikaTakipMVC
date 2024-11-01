using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace SertifikaKontrol.Controllers
{
    public class HomeScreenController : Controller
    {
        // Bu metot, belgelerin ana sayfasýný gösterir.
        public IActionResult Index()
        {
           
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true"; //Oturumun bu sayfada da açýk kalmasý için

            return View();
        }

        // Bu metot, belge listeleme iþlemi için bir sayfa gösterir.
        public IActionResult GetCertificate()
        {
            return View();
        }

        // Bu metot, bildirimlerle ilgili sayfayý gösterir.
        public IActionResult Notifications()
        {
            return View();
        }

        

    }
}