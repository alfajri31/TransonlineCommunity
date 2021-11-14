using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Transonline.Models.Authentication;
using Transonline.Data;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Transonline.Services
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {

        private readonly TransonlineDbContext db = new TransonlineDbContext();


        public override void OnAuthorization(HttpActionContext actionContext)
        {
         

            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my_secret_key_12345");
            tokenHandler.ValidateToken(authenticationToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            string username = jwtToken.Claims.First(x => x.Type == "username").Value;
            string email = jwtToken.Claims.First(x => x.Type == "email").Value;

            // attach user to context on successful jwt validation
            Role role = db.Role.FirstOrDefault(a => a.name=="Admin");
            if(role!=null)
            {
                var identity = new GenericIdentity(username);
                IPrincipal principal = new GenericPrincipal(identity, role.name.Split(','));

                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }

           
        }
    }
}