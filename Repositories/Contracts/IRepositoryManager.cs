using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager    //Tüm nesneleri yönetmek için kullanılan manager
    {                                     //Interface lerde sadece metot ve property olur. Kodun kendini tekrar etmemesi için bu yapıları kullanabiliriz.
        IApplicationRepository Application { get; }

        ICertificateRepository Certificate { get; }

        INotificationRepository Notification { get; }

        IEmployeeRepository Employee { get; }
        void Save();
    }
}
