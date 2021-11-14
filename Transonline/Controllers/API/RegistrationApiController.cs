using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Transonline.Data;
using Transonline.Models.Authentication;
using Transonline.Services;
using System.Web.Http.Cors;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Transonline.Controllers.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegistrationApiController : ApiController
    {
        private readonly TransonlineDbContext db = new TransonlineDbContext();

        // GET: api/Registers
        [Authorize]
        [BasicAuthentication]
        [MyAuthorizeAttributeWebApi(Roles = "Employee")]
        public IQueryable<Registration> GetRegister()
        {

            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return db.Registration;

            }
            return null;


        }

        // GET: api/Registers/5
        [ResponseType(typeof(Registration))]
        [CustomAuthorization]
        public IHttpActionResult GetRegister(string id)
        {
            Registration register = db.Registration.Find(id);
            if (register == null)
            {
                return NotFound();
            }

            return Ok(register);
        }

        // PUT: api/Registers/5
        [ResponseType(typeof(void))]
        [CustomAuthorization]
        public IHttpActionResult PutRegister(string id, Registration register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != register.Username)
            {
                return BadRequest();
            }

            db.Entry(register).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Registers
        [ResponseType(typeof(Registration))]
        [CustomAuthorization]
        public IHttpActionResult PostRegister(RegistrationDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            Registration register = new Registration
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                Password = passwordHash
            };

            db.Registration.Add(register);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RegisterExists(register.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = register.Username }, register);
        }

        // DELETE: api/Registers/5
        [ResponseType(typeof(Registration))]
        [CustomAuthorization]
        public IHttpActionResult DeleteRegister(string id)
        {
            Registration register = db.Registration.Find(id);
            if (register == null)
            {
                return NotFound();
            }

            db.Registration.Remove(register);
            db.SaveChanges();

            return Ok(register);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterExists(string id)
        {
            return db.Registration.Count(e => e.Username == id) > 0;
        }
    }
}