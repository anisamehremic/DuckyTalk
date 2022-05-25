using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace DuckyTalk.Integration.Entities.NewsApi
{
    public class Request
    {
        [Required]
        public int UserId { get; set; }
        public string Q { get; set; }
        public string Sources { get; set; }
        public int? PageSize { get; set; } 
        public int? Page { get; set; }
    }
}
