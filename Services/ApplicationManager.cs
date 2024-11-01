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
    public class ApplicationManager : IApplicationService
    {
        private readonly IRepositoryManager _manager; //Service ve repositories arasındaki bağlantı

        public ApplicationManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateApplication(Application application)
        {
            
            _manager.Application.Create(application);
            _manager.Save();
        }

        public IEnumerable<Application> GetAllApplications(bool trackChanges)
        {
            return _manager.Application.GetAllApplications(trackChanges);
        }

        public Application? GetOneApplication(int id, bool trackChanges)
        {
            
            var application = _manager.Application.GetOneApplication(id, trackChanges);
            if (application == null)
            {
                throw new Exception("Başvuru bulunamadı");
            }
            return application;
        }
        
        public void DeleteApplication(int id)
        {
            Application application=GetOneApplication(id,false);
            if (application != null)
            {
                _manager.Application.DeleteApplication(application);
                _manager.Save();
            }
        }
    }
}
