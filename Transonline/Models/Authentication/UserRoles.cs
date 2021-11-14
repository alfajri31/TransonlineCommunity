using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Transonline.Models.Authentication
{
    public class UserRoles : BaseEntity
    {
        public string RoleId { get; set; }

    }
}