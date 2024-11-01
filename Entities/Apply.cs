using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Apply
    {
        [Key]
        public int ApplyID { get; set; }
        public int? EmployeeID { get; set; }
        public int? CertificateID { get; set; } 
        public DateTime BasvuruTarihi { get; set; }
        public string Belgeler { get; set; }
        public bool OnayDurumu { get; set; }
        public DateTime OnayTarihi { get; set; }
        public int? OnaylayanYoneticiID { get; set; }
        public int? ReddedenYoneticiID { get; set; }
        public string RedSebebi { get; set; }
        public Employee? Employee { get; set; }
        public Certificate? Certificate { get; set; }
        public ICollection<Notification> Notifications { get; set; }//bire bir ilişki


    }
}
