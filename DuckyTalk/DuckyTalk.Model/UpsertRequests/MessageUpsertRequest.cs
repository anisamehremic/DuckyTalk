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
        public string TechnologyId { get; set; }
    }
}
