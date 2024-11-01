using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Application
    {
        [Key]   //Primary key yapmak için
        public int ApplicationID { get; set; }
        public int? ApplyID { get; set; } //F.K
        [ForeignKey("CertificateID")]
        public int? CertificateID { get; set; } //F.K.
        public int? EmployeeID { get; set; } //F.K.
        public DateTime BasvuruTarihi { get; set; }
        public string Belgeler { get; set; }
        public Certificate? Certificate { get; set; }
        public Employee? Employee { get; set; }  
        public Apply? Apply { get; set; }

        public ICollection<Notification> Notifications { get; set; }//bire bir ilişki

    }
}
