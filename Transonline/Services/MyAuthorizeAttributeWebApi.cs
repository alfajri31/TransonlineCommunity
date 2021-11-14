using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transonline.Models.Authentication;
using Transonline.Data;

namespace Transonline.Services
{
    public class MyAuthorizeAttributeWebApi : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //ignore the first condition because it has been authenticated in JWT this service is for role auth 
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }

    

    }
}