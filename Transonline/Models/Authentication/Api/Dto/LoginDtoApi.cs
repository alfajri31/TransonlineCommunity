using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Transonline.Models.Authentication.Api.Dto
{
    public class LoginDtoApi
    {
        [Required]
        [MinLength(2)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        public string Password { get; set; }
    }
}