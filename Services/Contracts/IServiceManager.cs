using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IApplicationService ApplicationService { get; }
        ICertificateService CertificateService { get; }
        INotificationService NotificationService { get; }
        IEmployeeService EmployeeService { get; }
    }
}
