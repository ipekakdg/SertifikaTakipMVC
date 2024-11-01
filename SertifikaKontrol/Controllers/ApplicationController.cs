using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace SertifikaKontrol.Controllers
{
    public class ApplicationController:Controller
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public ApplicationController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        // Bu metot, başvurularla ilgili sayfayı gösterir.
        public IActionResult Index()    //           Application/Index
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true"; //Oturumun açık olup olmadığını kontrol etme

            //var model = _manager.ApplicationService.GetAllApplications(false); //verileri getirdiğimiz yer

            if (HttpContext.Session.GetInt32("LoggedInEmployeeId").HasValue)//Oturumu açan personelde sesion value varsa
            {
                int loggedInEmployeeId=HttpContext.Session.GetInt32("LoggedInEmployeeId").Value; //Giriş yapan personelin id sini al
                var employeeApplications= _context.Applications.Where(a=>a.EmployeeID==loggedInEmployeeId).ToList();//Applications tablosundaki employeeId ile eşit olanları değişkene ata
                return View(employeeApplications); //Verileri göster
            }
            else
            {
                return RedirectToAction("Login","Login");
            }

            
        }
    }
}
