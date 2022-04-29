using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuckyTalk.Model.UpsertRequests
{
    public class TechnologyUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
