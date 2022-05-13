using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuckyTalk.Model.UpsertRequests
{
    public class MessageUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string MessageText { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Keywords { get; set; }

        public string TechnologyId { get; set; }
    }
}
