using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface INotificationRepository:IRepositoryBase<Notification>
    {
        IQueryable<Notification> GetAllNotifications(bool trackChanges);

    }
}
