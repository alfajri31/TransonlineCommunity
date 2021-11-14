using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Transonline.Data;
using Transonline.Models.Authentication;
using Transonline.Services;

namespace Transonline.Controllers
{
    [CustomAuthorization]
    public class RegistrationController : Controller
    {
        private readonly TransonlineDbContext db = new TransonlineDbContext();

        // GET: Registers
        [CustomAuthorization]
        public ActionResult Index()
        {
            return View(db.Registration.ToList());
        }

        // GET: Registers/Details/5
        [CustomAuthorization]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration register = db.Registration.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: Registers/Create
        [CustomAuthorization]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorization]
        public ActionResult Create([Bind(Include = "username,email,password")] RegistrationDto registerDto)
        {
            if (ModelState.IsValid)
            {

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

                Registration register = new Registration
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Password = passwordHash
                };
                db.Registration.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerDto);
        }

        // GET: Registers/Edit/5
        [CustomAuthorization]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration register = db.Registration.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorization]
        public ActionResult Edit([Bind(Include = "username,email,password")] Registration register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: Registers/Delete/5
        [CustomAuthorization]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration register = db.Registration.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorization]
        public ActionResult DeleteConfirmed(string id)
        {
            Registration register = db.Registration.Find(id);
            db.Registration.Remove(register);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
