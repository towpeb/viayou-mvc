using AutoMapper;
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
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class TravelsController : Controller
    {
        private ITravelRepository _travelsRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private ITransactionManager _transactionManager;


        public TravelsController(ITravelRepository travelRepository, ICountryRepository countryRepository, ICityRepository cityRepository,ITransactionManager transactionManager)
        {
            _travelsRepository = travelRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _transactionManager = transactionManager;
        }

        // GET: Admin/Travels
        public ActionResult Index()
        {
            //Return the travel list ordered by date
            var _travel = from travel in _travelsRepository.GetAll() orderby travel.Date ascending select travel;
            return View(_travel);
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

            var travel = _travelsRepository.GetById(id);

            if (travel == null)
               return HttpNotFound("travel not found");

            var data = Mapper.Map<TravelViewModel>(travel);

            data.CityDestinationList= new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityDestinationId);
            data.CityOriginList= new SelectList(_cityRepository.GetAll(), "Id", "Name", travel.CityOriginId);
            
            return View(data);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TravelViewModel data)
        {
            var travel = _travelsRepository.GetById(data.Id);

            if (travel==null)
               return HttpNotFound("travel not found");

            travel.Update(data.Date, data.Grade, data.Customer, data.Traveler, data.CityOrigin, data.CityDestination);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TravelViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var travel = new Travel(data.Date, data.Grade, data.CityOrigin, data.CityDestination, data.Customer, data.Traveler, data.Packages);
            _travelsRepository.Add(travel);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Search(string query)
        {
            var travel = from _travel in _travelsRepository.GetAll() where _travel.Traveler.FirstName.Contains(query) select _travel;
            return View(travel.ToList());
        }
        
       
    }
}
