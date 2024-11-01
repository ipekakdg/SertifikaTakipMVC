using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICertificateRepository : IRepositoryBase<Certificate>
    {
        IQueryable<Certificate> GetAllCertificates(bool trackChanges);

        Certificate? GetOneCertificate(int id,bool trackChanges);
        IQueryable<Certificate> GetDates(bool trackChanges);
        void CreateCertificates(Certificate certificate);
    }
}
