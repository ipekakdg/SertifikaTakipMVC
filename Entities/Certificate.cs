using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Certificate
    {
        [Key]
        public int SertifikaID { get; set; }
        public int? EmployeeID { get; set; }
        public string SertifikaAdi { get; set; }
        public string SertifikaNo { get; set; }
        public string SertifikaSaglayici { get; set; }
        public DateTime BitisTarihi { get; set; }

        public Employee? Employee { get; set; }

        public ICollection<Application> Applications { get; set; } //Bir sertifikanın birden fazla başvurusu olabilir 
        public ICollection<Apply> Applys { get; set; }//1 e bir ilişki

        public ICollection<ESignatureCertificate>  ESignatureCertificates { get; set; }//1 e bir ilişki

    }
}
