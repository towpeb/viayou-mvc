using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;
using ViaYou.Web.Helpers;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITransactionManager _transactionManager;

        public CitiesController(ICityRepository cityRepository, ICountryRepository countryRepository, ITransactionManager transactionManager)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var city = _cityRepository.GetById(id);

            if (city == null)
                return HttpNotFound("City not found.");

            return View("Delete", Mapper.Map<CityViewModel>(city));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _cityRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var city = _cityRepository.GetById(id);
            var countries = _countryRepository.GetAll().ToList();

            if (city == null)
                return HttpNotFound("City not found.");

            var data = Mapper.Map<CityViewModel>(city);
            data.AvailableCountries = countries.CreateSelectListItems(q => q.Name, q => q.Id.ToString(), q => q.Id == city.Country.Id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            var city = _cityRepository.GetById(data.Id);
            if (city == null)
                return HttpNotFound("City not found.");
            city.Update(data.Name, data.Code, _countryRepository.GetById(data.CountryId.Value));
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Country
        public ActionResult Index()
        {
            return View(_cityRepository.GetAll().OrderBy(x => x.Name).ToList());
        }

        public ActionResult Create()
        {
            var countries = _countryRepository.GetAll().ToList();
            return View(new CityViewModel
            {
                AvailableCountries = countries.CreateSelectListItems(x => x.Name, x => x.Id.ToString(), x => false)
            });
        }

        [HttpPost]
        public ActionResult Create(CityViewModel data)
        {
            _cityRepository.Add(new City
            {
                Code = data.Code,
                Name = data.Name,
                Country = _countryRepository.GetById(data.CountryId.Value)
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveCountries(string searchTerm, int pageSize, int pageNum)
        {
            var countries = _countryRepository.GetAll();
            var results = countries
                .Where(c => c.Name.Contains(searchTerm) || c.Code.Contains(searchTerm))
                .Select(c => new { id = c.Id, text = c.Name }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}