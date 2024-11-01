using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace SertifikaKontrol.Controllers
{
    public class LoginController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public LoginController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;        
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Employee employee)
        {
        if (ModelState.IsValid)
         {
          _manager.EmployeeService.CreateEmployee(employee);        // veritabanına personel ekle
              return View("Login");
         }
            return View();
        }

        public IActionResult Login() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Login(Employee employee)
        {
            //Application app= new Application();
            if (ModelState.IsValid)
            {
                //eğer kullanıcıadı şifre eşleşiyorsa user değişkenine giriş yapan kullanıcıyı ata
                var user = _context.Employees.SingleOrDefault(e => e.KullaniciAdi== employee.KullaniciAdi && e.Sifre ==employee.Sifre);
                if (user != null)  //kullanıcı varsa
                {
                    var LoggedInEmployeeId = user.EmployeeID;    //giriş yapan kullanıcının personelId sini değişkene ata
                    HttpContext.Session.SetInt32("LoggedInEmployeeId", LoggedInEmployeeId); //üst satırda atadığımız değişkeni giriş yapan kullanıcının oturum value yap
                    HttpContext.Session.SetString("KullaniciAdi", employee.KullaniciAdi); //Personel kullanıcıadını Session da kullaniciadi keyinin value olarak ata
                    HttpContext.Session.SetString("IsLoggedIn", "true"); //Giriş yapıp yapmadığını kontrol ettiğimiz yer için tanımladığımız key value
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı."); //Giriş yapmış kullanıcı yoksa
                }
            }
            return View(employee);

        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Clear(); //Çıkış yaptığında session ı kapat
            return RedirectToAction("Login", "Login");  //Giriş yap sayfasına yönlendir.
        }
    }
}
