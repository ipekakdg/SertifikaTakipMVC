using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IApplicationService _applicationService;
        private readonly ICertificateService _certificateService;
        private readonly INotificationService _notificationService;
        private readonly IEmployeeService _employeeService;

        public ServiceManager(IApplicationService applicationService, ICertificateService certificateService, INotificationService notificationService, IEmployeeService employeeService)
        {
            _applicationService = applicationService;
            _certificateService = certificateService;
            _notificationService = notificationService;
            _employeeService = employeeService;
        }

        public IApplicationService ApplicationService => _applicationService;
        public ICertificateService CertificateService => _certificateService;
        public INotificationService NotificationService => _notificationService;
        public IEmployeeService EmployeeService => _employeeService;
    }
}
