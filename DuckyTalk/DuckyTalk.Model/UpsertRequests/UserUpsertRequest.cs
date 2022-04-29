using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DuckyTalk.Model.UpsertRequests
{
    public class UserUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Username { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string PasswordConfirmation { get; set; }
    }
}
