using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NotificationRecord
    {
        [Key]
        public int NotificationRecordID { get; set; }
        public int? NotificationID { get; set; }
        public int? NotificationTypeID { get; set; }
        public DateTime GonderilenTarih { get; set; }

        public Notification? Notification { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}
