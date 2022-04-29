using System;
using System.Collections.Generic;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class Technology
    {
        public int TechnologyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
