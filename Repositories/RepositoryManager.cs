using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager  //Controllers yapısına erişecek sınıf
    {
        private readonly RepositoryContext _context; //Context üzerinde kayıtlı işlem yapılması için

        private readonly IApplicationRepository _applicationRepository;

        private readonly ICertificateRepository _certificateRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext context, IApplicationRepository applicationRepository, ICertificateRepository certificateRepository, INotificationRepository notificationRepository,IEmployeeRepository employeeRepository)
        {
            _context = context;
            _applicationRepository = applicationRepository;   //AddScoped kolaylığı
            _certificateRepository = certificateRepository;
            _notificationRepository = notificationRepository;
            _employeeRepository = employeeRepository;
        }

        public IApplicationRepository Application => _applicationRepository; //Sınıf üzerinden Application a erişilmek istenirse _applicationRepo ya ulaşılması için
        public ICertificateRepository Certificate => _certificateRepository;
        public INotificationRepository Notification => _notificationRepository;
        public IEmployeeRepository Employee => _employeeRepository;

        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
