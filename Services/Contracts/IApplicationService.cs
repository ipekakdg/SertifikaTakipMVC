using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IApplicationService
    {
        IEnumerable<Application> GetAllApplications(bool trackChanges);
        Application? GetOneApplication(int id, bool trackChanges);
        void CreateApplication(Application application);

        void DeleteApplication(int id);

    }
}
