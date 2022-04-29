using System;
using System.Collections.Generic;
using System.Text;

namespace DuckyTalk.Model
{
    public class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
