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
    public class NotificationManager : INotificationService
    {
        private readonly IRepositoryManager _manager;

        public NotificationManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateNotification(Notification notification)
        {
            _manager.Notification.Create(notification);
            _manager.Save();
        }

        public IEnumerable<Notification> GetAllNotifications(bool trackChanges)
        {
            return _manager.Notification.GetAllNotifications(trackChanges);
        }
    }
}
