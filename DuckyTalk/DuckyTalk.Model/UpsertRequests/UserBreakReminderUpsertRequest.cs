using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuckyTalk.Model.UpsertRequests
{
    public class UserBreakReminderUpsertRequests
    {
        [Required(AllowEmptyStrings = false)]
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool BreakNotificationsEnabled { get; set; }
        public bool EndTimeNotificationsEnabled { get; set; }
    }
}
