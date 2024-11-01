using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository   // Devraldığımız nesne class ı 
    {
        public ApplicationRepository(RepositoryContext context) : base(context)  
        {
        }

        public void CreateApplication(Application application)
        {
            throw new NotImplementedException();
        }

        public void DeleteApplication(Application application) => Remove(application);
        

        public IQueryable<Application> GetAllApplications(bool trackChanges) => FindAll(trackChanges); //IQueryable veritabanındaki verileri liste halinde döndürmek için

        public Application? GetOneApplication(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ApplicationID.Equals(id), trackChanges);

        }
        //Başvuruları listelemek için metot

    }
}
