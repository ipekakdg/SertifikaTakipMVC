using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Tls;
using Repositories;
using SertifikaKontrol.Models;
using Services.Contracts;
using System;

namespace SertifikaKontrol.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApplicationController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;


        public ApplicationController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        public IActionResult Index()
        {
            //var model = _manager.ApplicationService.GetAllApplications(false);  //Bütün kullanıcıların başvurularını getirme
            //return View(model);

            var applications = _context.Applications.Include(a=>a.Employee).ToList();
            ViewBag.EmployeeUserNames= applications.Select(a=>a.Employee?.KullaniciAdi).ToList();
            return View(applications);

        }

        public ActionResult Refuse(int id)
        {
            try
            {
                var application = _context.Applications.FirstOrDefault(a => a.ApplicationID == id);
                if (application == null)
                {
                    ViewData["Error"] = "Başvuru bulunamadı";
                    return View();
                }

            //var silinecekBasvuru = _context.Applications.Find(id);

            //if (silinecekBasvuru != null)
            //{
            //    _context.Applications.Remove(silinecekBasvuru);
            //    _context.SaveChanges();
            //}

            var newNotification = new Notification
                {
                    EmployeeID = application.EmployeeID,
                    ApplyID = application.ApplyID,
                    ApplicationID = application.ApplicationID,
                    BildirimMetni = "e-imza sertifika güncelleme talebiniz reddedilmiştir.",
                    Tarih = DateTime.Now
                };

                _manager.NotificationService.CreateNotification(newNotification);
            // _manager.ApplicationService.DeleteApplication(id);
            


            ViewData["Success"] = "Başvuruyu başarıyla reddettin. İlgili kullanıcıya bildirim metni gönderildi.";
            return View();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Başvuru reddedilirken bir hatayla karşılaştık. Hata metni: {ex.Message}";
                return View();
            }
        }


        public IActionResult Accept(int applicationId)
        {
            try
            {
                var application = _context.Applications.FirstOrDefault(a => a.ApplicationID == applicationId); //Seçtiğimiz başvuruya göre application alma işlemi
                if (application == null)
                {
                    ViewData["Error"] = "Başvuru bulunamadı";
                    return View();
                }

                var newNotification = new Notification
                {
                    EmployeeID = application.EmployeeID,  
                    ApplyID = application.ApplyID,
                    ApplicationID = application.ApplicationID,
                    BildirimMetni = "e-imza sertifika güncelleme talebiniz onaylanmıştır.",
                    Tarih = DateTime.Now
                };

                // Yeni bildirimi veritabanına ekle
                _context.Notifications.Add(newNotification);
                _context.SaveChanges();
                ViewData["Success"] = "Başvuruyu başarıyla onayladın. İlgili kullanıcıya bildirim metni gönderildi.";

                return View();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Başvuruyu onaylarken bir hatayla karşılaştık. Hata metni: {ex.Message}";
                return View();
            }

        }

        public IActionResult UpdateCerDate(int appId)
        {
            try
            {
                // application i bul
                var application = _context.Applications
                    .Include(a => a.Certificate)  // ilgili sertifikayı yüklemek için include
                    .FirstOrDefault(a => a.ApplicationID == appId);

                if (application == null || application.Certificate == null)
                {
                    ViewData["Error"] = "Hata: Başvuru veya sertifika bulunamadı.";
                    return View();
                }
                //Sertifikanın daha önce güncellenip güncellenmediğini kontrol
                if (application.Certificate.BitisTarihi >= DateTime.Now.AddYears(1))  
                {
                    ViewData["Error"] = "Sertifika zaten bir yıl veya daha fazla bir süre için uzatılmış.";
                    return View();
                }
                // Certificate'ın bitiş tarihini bir yıl sonraya ertele
                application.Certificate.BitisTarihi = application.Certificate.BitisTarihi.AddYears(1);

                // Değişiklikleri kaydet
                _context.Update(application.Certificate);
                _context.SaveChanges();

                ViewData["Success"] = "Sertifika bitiş tarihi başarıyla güncellendi.";
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Hata: {ex.Message}";
                return View();
            }

        }
    }
}

    
    
