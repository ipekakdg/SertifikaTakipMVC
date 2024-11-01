using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NotificationType
    {
        [Key]
        public int NotificationTypeID { get; set; }
        public string TipAdi { get; set; }
        public ICollection<NotificationRecord> NotificationRecords { get; set; }//bire bir ilişki
    }
}
