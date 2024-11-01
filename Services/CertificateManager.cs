using Entities;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CertificateManager : ICertificateService
    {
        private readonly IRepositoryManager _manager;

        public CertificateManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCertificate(Certificate certificate)
        {
            _manager.Certificate.Create(certificate);
            _manager.Save();
        }

        public IEnumerable<Certificate> GetCertificates(bool trackChanges)
        {
            return _manager.Certificate.GetAllCertificates(trackChanges);
        }

        public IEnumerable<Certificate> GetDate()
        {
            throw new NotImplementedException();
        }

        public Certificate? GetOneCertificate(int id, bool trackChanges)
        {
            var certificate = _manager.Certificate.GetOneCertificate(id, trackChanges);
            if (certificate == null)
            {
                throw new Exception("Başvuru bulunamadı");
            }
            return certificate;
        }

        public void UpdateCertificate(Certificate certificate)
        {
            var entity = _manager.Certificate.GetOneCertificate(certificate.SertifikaID, true);
            entity.BitisTarihi = certificate.BitisTarihi.AddYears(1);
            _manager.Save();
        }
    }
}
