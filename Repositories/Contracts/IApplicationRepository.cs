using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IApplicationRepository:IRepositoryBase<Application>    //Crud işlemlerini kullanabilmek için ekleme silme güncelleme getirme
    {
        IQueryable<Application> GetAllApplications(bool trackChanges);
        Application? GetOneApplication(int id, bool trackChanges);
        void CreateApplication(Application application);

        void DeleteApplication(Application application);
    }
}
