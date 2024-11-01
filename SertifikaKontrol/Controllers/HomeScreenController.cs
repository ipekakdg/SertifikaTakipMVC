using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace SertifikaKontrol.Controllers
{
    public class HomeScreenController : Controller
    {
        // Bu metot, belgelerin ana sayfas�n� g�sterir.
        public IActionResult Index()
        {
           
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true"; //Oturumun bu sayfada da a��k kalmas� i�in

            return View();
        }

        // Bu metot, belge listeleme i�lemi i�in bir sayfa g�sterir.
        public IActionResult GetCertificate()
        {
            return View();
        }

        // Bu metot, bildirimlerle ilgili sayfay� g�sterir.
        public IActionResult Notifications()
        {
            return View();
        }

        

    }
}