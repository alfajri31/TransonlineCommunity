using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transonline.Models.Authentication
{
    public class Registration
    {

        [Key]
        [Column(Order = 1)]
        public string Email { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}