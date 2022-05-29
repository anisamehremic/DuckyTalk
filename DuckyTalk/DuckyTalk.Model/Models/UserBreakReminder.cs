using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class UserBreakReminder
    {
        public int UserBreakReminderId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool BreakNotificationsEnabled { get; set; }
        public bool EndTimeNotificationsEnabled { get; set; }
    }
}
