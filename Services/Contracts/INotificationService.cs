using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetAllNotifications(bool trackChanges);
        void CreateNotification(Notification notification);
    }
}
