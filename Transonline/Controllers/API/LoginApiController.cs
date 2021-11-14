using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Transonline.Data;
using Transonline.Models.Authentication;
using Transonline.Models.Authentication.Api;
using Transonline.Models.Authentication.Api.Dto;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Transonline.Controllers.API 
{

    public class LoginApiController : ApiController
    {
        private readonly TransonlineDbContext db = new TransonlineDbContext();

        [HttpPost]
        public IHttpActionResult PostLogin(LoginDtoApi loginDtoApi)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LoginApi loginApi = new LoginApi { };
            Registration register = db.Registration.SingleOrDefault(a => a.Username== loginDtoApi.Username);
            if (register!= null)
            {
                if(register.Password == loginDtoApi.Password)
                {
                    loginApi.Username = loginDtoApi.Username;
                    loginApi.token = GetToken(register);
                    loginApi.Message = "This user has authenticated ";
                }
                else
                {
                    return NotFound();
                }
            
            }
            else
            {
                return NotFound();
            }
            return Ok(loginApi);
        }

        public Object GetToken(Registration register)
        {

            string key = "my_secret_key_12345"; //Secret key which will be used later during validation    
            var issuer = "http://mysite.com";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("password", register.Password));
            permClaims.Add(new Claim("email", register.Email));
            permClaims.Add(new Claim("username", register.Username));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }
    }

   

   
}