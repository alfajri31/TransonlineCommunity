using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transonline.Models.Authentication
{
    public class UserRoleMapping : BaseEntity
    { 
        
        public Registration registration { get; set; }
        public Role role { get; set; }
    }
}