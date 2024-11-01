using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CertificateRepository : RepositoryBase<Certificate>, ICertificateRepository
    {
        public CertificateRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCertificates(Certificate certificate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Certificate> GetAllCertificates(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Certificate> GetDates(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Certificate? GetOneCertificate(int id, bool trackChanges)
        {
            return FindByCondition(p => p.SertifikaID.Equals(id),trackChanges);
        }
    }
}
