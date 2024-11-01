using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Repositories.Contracts;
using SertifikaKontrol.Models;
using MailKit.Net.Smtp;
using Services.Contracts;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Repositories;
using Entities;

namespace SertifikaKontrol.Controllers
{
    public class CertificateController : Controller
    {
        private readonly IServiceManager _manager;


        private RepositoryContext _context;

        public CertificateController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";

            int loggedInEmployeeId = HttpContext.Session.GetInt32("LoggedInEmployeeId").GetValueOrDefault();//giriş yapan personelid değerini ara bulamazsa 0 döndürür

            var employeeCertificate=_context.Certificates.FirstOrDefault(c=>c.EmployeeID==loggedInEmployeeId); //First or Default ilk ögeyi getirir. Sertifika 1 tane olduğu için bir tane getirdik.
            if (employeeCertificate == null)
            {
                throw new Exception("Sertifikanız bulunamadı.");
            }
            
            try
            {
                var newApplication = new Application   //Başvuru ekleme
                {
                    ApplyID = 1,    //işlem yapmadığımız için applyId ile default 1 ekledik
                    CertificateID = employeeCertificate.SertifikaID, //Oturum açan personelin sertifikaId si
                    EmployeeID = loggedInEmployeeId,   //Oturum açan kullanıcının id si 29. satırda çekmiştik.
                    BasvuruTarihi = DateTime.Now,     //yerel saat olarak başvuru tarihi ata
                    Belgeler = "E-imza Sertifikası"
                };
                _manager.ApplicationService.CreateApplication(newApplication); //servislerden başvuru oluştur
                ViewData["Success"] = "Başvurunuz başarıyla gönderildi.";  //buraya kadar işlemleri yaptıysa viewdata success e metni ata
                return View();

            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Başvurunuz gönderilirken bir sorunla karşılaşıldı. Hata Metni: {ex.Message}"; //Hata alırsak Viewdata error a ata
                return View();
            }
            
        }


        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";

            //var model = _manager.CertificateService.GetCertificates(false);

            if (HttpContext.Session.GetInt32("LoggedInEmployeeId").HasValue)
            {
                int loggedInEmployeeId = HttpContext.Session.GetInt32("LoggedInEmployeeId").Value;
                var employeeCertificate = _context.Certificates.Where(c => c.EmployeeID == loggedInEmployeeId).ToList();
                return View(employeeCertificate);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult SendMail()
        {
            return View();
        }

        ////[HttpPost]
        ////public IActionResult SendMail(EmailData emailData)   //mail göndermek için post yöntemiyle oluşturduğum IActionResult
        ////{
        ////    var email = new MimeMessage();  // E-postayı temsil etmek için yeni bir MimeMessage nesnesi oluşturulur.

        ////    email.From.Add(MailboxAddress.Parse(emailData.From));  // Gönderenin e-posta adresi belirlenir.
        ////    email.To.Add(MailboxAddress.Parse(emailData.To));     // Alıcının e-posta adresi eklenir.
        ////    email.Subject = emailData.Subject;               // E-posta konusu belirlenir
        ////    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailData.Body };   // HTML formatında e-posta içeriği belirlenir.
        ////    try { 
        ////    using var smtp = new SmtpClient();    // E-postayı göndermek için SmtpClient sınıfının bir örneği oluşturulur.
        ////      //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);    // Kullanmak istediğiniz SMTP sunusuna bağlanmak için aşağıdaki satırlardan birini yorumdan çıkarın.
        ////    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);   //gmail kullanabilmek için
        ////    smtp.Authenticate(emailData.From, emailData.Password);    // Gönderenin kimlik bilgileri ile SMTP sunusuna kimlik doğrulaması yapılır.
        ////    smtp.Send(email);  // SmtpClient kullanılarak e-posta gönderilir
        ////    smtp.Disconnect(true);  // E-postayı gönderdikten sonra SMTP sunusundan bağlantı kesilir.
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw;
        ////    }

        ////    return RedirectToAction("SentEmail");
        ////}

        //public IActionResult SentEmail()
        //{
        //    ViewData["Success"] = "Email başarıyla gönderildi!";
        //    return View();
        //}

        public ActionResult SendEmail(EmailData emailData)
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";

            DateTime sertifikaTarihi = _context.Certificates.Select(k => k.BitisTarihi).FirstOrDefault(); //certificate tablosundan bitiş tarihi seç
            DateTime bugun = DateTime.Now;
            DateTime bildirimTarihi = sertifikaTarihi.AddDays(-30); //en erken bitiş tarihi 30 gün kalan sertifikalar için bildirim at


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailData.From));
            email.To.Add(MailboxAddress.Parse("zekeriya1668@gmail.com")); //değiştirmeyi unutmayın.
            email.Subject = "E-Sertifika Kontrol";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "E-imza sertifikanızın güncelleme tarihi yaklaşmıştır." };


            if (bugun >= bildirimTarihi)
            {
                try
                {
                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate(emailData.From, emailData.Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);

                    ViewData["Success"] = "E-mail bildirim ayarınız başarıyla tamamlanmıştır";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = $"{ex.Message}";
                    return View();

                }
            }
            else
            {
                ViewData["Error"] = "E-imza sertifikanızı güncelleme tarihiniz çok uzak bir zamanda veya geçmiş. Lütfen sertifikanızın bitiş tarihini kontrol ediniz.";
                return View();
                

            }
        }

    

        public ActionResult SendSms()
        {
                ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";


                DateTime sertifikaTarihi = _context.Certificates.Select(k=>k.BitisTarihi).FirstOrDefault();
                DateTime bugun = DateTime.Now;
                DateTime bildirimTarihi = sertifikaTarihi.AddDays(-30);

                if (bugun >= bildirimTarihi)
                {
                    try
                    {
                        string accountSid = "";   
                        string authToken = "";

                        TwilioClient.Init(accountSid, authToken);  //Twilio client hesabını tanıma

                        var message = MessageResource.Create(   //sms özelliklerini tanıtma
                            body: "E-imza sertifikanizin guncelleme tarihi yaklasmistir.",
                            from: new Twilio.Types.PhoneNumber(""),
                            to: new Twilio.Types.PhoneNumber(""));

                        ViewData["Success"] = "Sms bildirim ayarınız başarıyla tamamlanmıştır";
                        return View();
                    }
                    catch (Exception ex)
                    {
                        // Twilio'dan gelen hatayı kontrol et
                        ViewData["Error"] = $"Twilio Error: {ex.Message}";
                        return View();
                    }
                }
                else
                {
                ViewData["Error"] = "E-imza sertifikanızı güncelleme tarihiniz çok uzak bir zamanda veya geçmiş. Lütfen sertifikanızın bitiş tarihini kontrol ediniz.";
                    return View();

                }
            }
           // else { return View(); }
        
    }
}

