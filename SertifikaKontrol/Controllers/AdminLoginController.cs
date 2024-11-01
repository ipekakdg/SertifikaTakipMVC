using Microsoft.AspNetCore.Mvc;
using SertifikaKontrol.Models;

namespace SertifikaKontrol.Controllers
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminLoginModel model)
        {

            if (ModelState.IsValid)
            {

            if (IsValidUser(model.Username,model.Password))
            {
                return RedirectToAction("Index", "Dashboard", new {area="Admin"});
            }
            else {
                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
                return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        private bool IsValidUser(string username, string password)
        {
            // Kullanıcı adı ve şifreyi kontrol et, örneğin bir veritabanından kontrol edilebilir
            // Bu örnekte basit bir kontrol yapısı kullanılmıştır, gerçek projelerde daha güvenli bir yöntem kullanılmalıdır.
            return (username == "admin" && password == "admin123");
        }

    }
}
