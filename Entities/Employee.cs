using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? PersonelNo { get; set; }
        public string? Pozisyon { get; set; }
        public string? Departman { get;set; }
        public string? Email { get;set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime? IseGirisTarihi { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public ICollection<Application>? Applications { get; set; } //Bir personelin birden fazla başvurusu olabilir
        public ICollection<Certificate>? Certificates { get; set; } //Bir personelin birden fazla sertifikası olabilir 
        public ICollection<Apply>? Applies { get; set; }// Bir personelin birden fazla başvurusu onaylanabilir
        public ICollection<Notification>? Notifications { get; set; }//Bir personelin birden fazla bildirimi olabilir 
        public ICollection<NotificationPreference>? NotificationPreferences { get; set; }//Bir personelin birden fazla bildirim tercihi olabilir


    }
}