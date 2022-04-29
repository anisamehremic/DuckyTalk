using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class UserTechnology
    {
        public int UserTechnologyId { get; set; }
        public int UserId { get; set; }
        public int TechnologyId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
