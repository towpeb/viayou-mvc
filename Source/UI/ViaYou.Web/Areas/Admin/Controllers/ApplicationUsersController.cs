﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViaYou.Data;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Users;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class ApplicationUsersController : Controller
    {
        //private ViaYouDataContext db = new ViaYouDataContext();
        private IApplicationUserRepository _usserRepository;
        private ITransactionManager _transactionManager;

        public ApplicationUsersController(IApplicationUserRepository usserRepository,ITransactionManager transactionManager)
        {
            _usserRepository = usserRepository;
            _transactionManager = transactionManager;
        }

        // GET: Admin/ApplicationUsers
        public ActionResult Index()
        {
            return View(_usserRepository.GetAll().OrderByDescending(u=>u.FirstName).ToList());
        }

        // GET: Admin/ApplicationUsers/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        // GET: Admin/ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Admin/ApplicationUsers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUserViewModel data)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = data.FirstName;
                user.Email = data.Email;
               // user.EmailConfirmed = data.EmailConfirmed;
                user.LastName = data.LastName;
                user.MiddleName = data.MiddleName;
                user.UserName = data.UserName;
                user.PhoneNumber = data.PhoneNumber;
                _usserRepository.Add(user);
                _transactionManager.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        // GET: Admin/ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationUser = _usserRepository.GetById(id); 
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var data = Mapper.Map<ApplicationUserViewModel> (applicationUser);
            return View(data);
        }

        //// POST: Admin/ApplicationUsers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUserViewModel data)
        {
            if (ModelState.IsValid)
            {
                var user = _usserRepository.GetById(data.Id);

                user.Update(data.FirstName, data.LastName, data.MiddleName, data.UserName, data.PhoneNumber, data.Email);
                _transactionManager.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        //// GET: Admin/ApplicationUsers/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationUser);
        //}

        //// POST: Admin/ApplicationUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ApplicationUser applicationUser = db.ApplicationUsers.Find(id);
        //    db.ApplicationUsers.Remove(applicationUser);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
