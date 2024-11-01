using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace SertifikaKontrol.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public NotificationController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true"; //Oturumun bu sayfada da açık kalması için

            //var model = _manager.NotificationService.GetAllNotifications(false);
            if (HttpContext.Session.GetInt32("LoggedInEmployeeId").HasValue)
            {
                int loggedInEmployeeId = HttpContext.Session.GetInt32("LoggedInEmployeeId").Value;
                var employeeNotifications = _context.Notifications.Where(n=>n.EmployeeID == loggedInEmployeeId).ToList();//giriş yapan personelin bildirimlerini alma
                return View(employeeNotifications);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }
    }
}
