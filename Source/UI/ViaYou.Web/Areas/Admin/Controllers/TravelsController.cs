using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViaYou.Data;
using ViaYou.Data.Repositories;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class TravelsController : Controller
    {
        private ITravelRepository _travelsRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private ITransactionManager _transactionManager;


        public TravelsController(ITravelRepository travelRepository, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _travelsRepository = travelRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        // GET: Admin/Travels
        public ActionResult Index()
        {
           return View(_travelsRepository.GetAll().ToList());
        }

        //GET: Admin/Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = _travelsRepository.GetById(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }




        //// GET: Admin/Travels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = _travelsRepository.GetById(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityDestinationId = new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityDestinationId);
            ViewBag.CityOriginId = new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityOriginId);
            return View(travel);
        }

        // POST: Admin/Travels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Grade,CustomerId,TravelerId,CityOriginId,CityDestinationId")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                _travelsRepository.Update(travel);
                return Redirect("Index");
            }
            ViewBag.CityDestinationId = new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityDestinationId);
            ViewBag.CityOriginId = new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityOriginId);
            return View(travel);
        }

        //// GET: Admin/Travels/Delete/5
       
    }
}
