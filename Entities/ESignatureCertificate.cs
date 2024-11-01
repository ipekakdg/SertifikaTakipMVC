using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ESignatureCertificate
    {
        [Key]
        public int EimzaSertifikaID { get; set; }
        public int? CertificateID { get; set; }
        public string SertifikaNo { get; set; }
        public string SertifikaSahibi { get; set; }
        public string EimzaDosyaYolu { get; set; }
        public Certificate? Certificate { get; set; }
    }
}
