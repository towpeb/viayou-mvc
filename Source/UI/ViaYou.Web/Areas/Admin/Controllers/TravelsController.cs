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
using ViaYou.Domain.Travels;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class TravelsController : Controller
    {
        //private ViaYouDataContext db = new ViaYouDataContext();
        private ITravelRepository _travelsRepository;

        // GET: Admin/Travels
        public ActionResult Index()
        {
            //var travels = db.Travels.Include(t => t.CityDestination).Include(t => t.CityOrigin);
            var travels = _travelsRepository.GetAll();
            return View(travels.ToList());
        }

        // GET: Admin/Travels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Travel travel = db.Travels.Find(id);
        //    if (travel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(travel);
        //}

        //// GET: Admin/Travels/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CityDestinationId = new SelectList(db.Cities, "Id", "Name");
        //    ViewBag.CityOriginId = new SelectList(db.Cities, "Id", "Name");
        //    return View();
        //}

        //// POST: Admin/Travels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Date,Grade,CustomerId,TravelerId,CityOriginId,CityDestinationId")] Travel travel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Travels.Add(travel);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CityDestinationId = new SelectList(db.Cities, "Id", "Name", travel.CityDestinationId);
        //    ViewBag.CityOriginId = new SelectList(db.Cities, "Id", "Name", travel.CityOriginId);
        //    return View(travel);
        //}

        //// GET: Admin/Travels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Travel travel = db.Travels.Find(id);
        //    if (travel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CityDestinationId = new SelectList(db.Cities, "Id", "Name", travel.CityDestinationId);
        //    ViewBag.CityOriginId = new SelectList(db.Cities, "Id", "Name", travel.CityOriginId);
        //    return View(travel);
        //}

        //// POST: Admin/Travels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Date,Grade,CustomerId,TravelerId,CityOriginId,CityDestinationId")] Travel travel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(travel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CityDestinationId = new SelectList(db.Cities, "Id", "Name", travel.CityDestinationId);
        //    ViewBag.CityOriginId = new SelectList(db.Cities, "Id", "Name", travel.CityOriginId);
        //    return View(travel);
        //}

        //// GET: Admin/Travels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Travel travel = db.Travels.Find(id);
        //    if (travel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(travel);
        //}

        //// POST: Admin/Travels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Travel travel = db.Travels.Find(id);
        //    db.Travels.Remove(travel);
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
