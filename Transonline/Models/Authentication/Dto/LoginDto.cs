using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Transonline.Models.Authentication.Dto
{
    public class LoginDto
    {
        [Required]
        [MinLength(2)]
        public string Username { get; set; }
        [MinLength(2)]
        public string Email { get; set; }
        [Required]
        [MinLength(2)]
        public string password { get; set; }
    }
}