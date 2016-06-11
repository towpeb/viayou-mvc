using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ITransactionManager _transactionManager;

        public CountriesController(ICountryRepository countryRepository, ITransactionManager transactionManager)
        {
            _countryRepository = countryRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var country = _countryRepository.GetById(id);

            if (country == null)
                return HttpNotFound("Country not found.");

            return View("Delete", Mapper.Map<CountryViewModel>(country));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _countryRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var country = _countryRepository.GetById(id);
            if (country == null)
                return HttpNotFound("Country not found");
            return View(Mapper.Map<CountryViewModel>(country));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryViewModel data)
        {
            var country = _countryRepository.GetById(data.Id);
            if (country == null)
                return HttpNotFound("Country not found.");
            country.Update(data.Name, data.Code);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Country
        public ActionResult Index()
        {
            return View(_countryRepository.GetAll().OrderBy(x=>x.Name).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryViewModel data)
        {
            _countryRepository.Add(new Country
            {
                Code = data.Code,
                Name = data.Name
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
                .Select(c => new {id = c.Id, text = c.Name}).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}