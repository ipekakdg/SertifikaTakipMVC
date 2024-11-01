using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ApplyID { get; set; }
        public int? ApplicationID { get; set; }
        public string BildirimMetni { get; set; }
        public DateTime Tarih { get; set; }

        public Employee? Employee { get; set; }
        public Application? Application { get; set; }
        public Apply? Apply { get; set; }
        public ICollection<NotificationRecord> NotificationRecords { get; set; }//bire bir ilişki
    }
}
