using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transonline.Models.Authentication
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Active { get; set; }

        public string LastLoginDate { get; set; }
    }
}