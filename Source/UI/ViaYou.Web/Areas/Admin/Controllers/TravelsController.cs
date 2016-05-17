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
using ViaYou.Web.Helpers;


namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class TravelsController : Controller
    {
        private ITravelRepository _travelsRepository;
        private ICityRepository _cityRepository;
        private ITransactionManager _transactionManager;
        private IApplicationUserRepository _applicationUser;

        public TravelsController(ITravelRepository travelRepository, ICityRepository cityRepository,ITransactionManager transactionManager,IApplicationUserRepository applicationUser)
        {
            _travelsRepository = travelRepository;
            _cityRepository = cityRepository;
            _transactionManager = transactionManager;
            _applicationUser = applicationUser;

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
            var cities = _cityRepository.GetAll().ToList();
            var user = _applicationUser.GetAll().ToList();

            if (travel == null)
               return HttpNotFound("travel not found");

            var data = Mapper.Map<TravelViewModel>(travel);
            data.CitiesList = cities.CreateSelectListItems(c => c.Name, c => c.Id.ToString());
            data.Users = user.CreateSelectListItems(u => u.FirstName+u.LastName, u => u.Id.ToString());
            return View(data);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TravelViewModel data)
        {
            var travel = _travelsRepository.GetById(data.Id);

            if (travel==null)
               return HttpNotFound("travel not found");

            travel.Update(data.Date, data.Grade);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            var cities = _cityRepository.GetAll().ToList();
            var user = _applicationUser.GetAll().ToList();
            return View(new TravelViewModel
            {
                Date = System.DateTime.Now,
                CitiesList = cities.CreateSelectListItems(c => c.Name, c => c.Id.ToString(), c => false),
                Users=user.CreateSelectListItems(u=>u.FirstName,u=>u.Id.ToString(),u=>false)
            });
        }

        [HttpPost]
        public ActionResult Create(TravelViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
                        
            _travelsRepository.Add(new Travel
            {
                Date = data.Date,
                //Grade = data.Grade,
                CityOrigin = _cityRepository.GetById(data.CityOriginId.Value),
                CityDestination = _cityRepository.GetById(data.CityDestinationId.Value),
                Customer=_applicationUser.GetById(data.CustomerId.Value.ToString()),
                Traveler=_applicationUser.GetById(data.TravelerId.Value.ToString())
                
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Search(string query)
        {
            var travel = from _travel in _travelsRepository.GetAll().Take(10) where _travel.Traveler.FirstName.Contains(query) select _travel;
            //travel=_travelsRepository
            if (travel==null)
            {
                return HttpNotFound("there is no traveler with such a name");
            }
            
            return View(travel.ToList());
        }
        
       
    }
}
