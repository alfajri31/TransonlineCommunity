using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transonline.Models.Authentication.Api
{
    public class LoginApi
    {
        public Object token { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }
}