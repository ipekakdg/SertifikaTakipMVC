using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NotificationPreference
    {
        [Key]
        public int NotificationPreferenceID { get; set; }
        public int? EmployeeID { get; set; }
        public bool EpostaBildirim { get; set; }
        public bool SMSBildirim { get; set; }
        public Employee? Employee { get; set; }
    }
}
