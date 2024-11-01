using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICertificateService
    {
        IEnumerable<Certificate> GetCertificates(bool trackChanges);
        void CreateCertificate(Certificate certificate);

        Certificate? GetOneCertificate(int id,bool trackChanges);
        IEnumerable<Certificate> GetDate();

        void UpdateCertificate(Certificate certificate);
    }
}
