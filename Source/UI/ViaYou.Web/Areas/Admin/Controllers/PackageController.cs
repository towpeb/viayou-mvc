using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;
using ViaYou.Web.Helpers;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly ITransactionManager _transactionManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly ITravelRepository _travelRepository;

        public PackageController(IPackageRepository packageRepository,
                                 ICategoryRepository categoryRepository,
                                 ITransactionManager transactionManager,
                                 IContainerRepository containerRepository,
                                 ITravelRepository travelRepository)
        {
            _packageRepository = packageRepository;
            _categoryRepository = categoryRepository;
            _containerRepository = containerRepository;
            _travelRepository = travelRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _packageRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Package not found.");

            return View("Delete", Mapper.Map<PackageViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _packageRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var package = _packageRepository.GetById(id);
            var categories = _categoryRepository.GetAll().Project().To<CategoryViewModel>();
            var containers = _containerRepository.GetAll().Project().To<ContainerViewModel>();
            var travels = _categoryRepository.GetAll().Project().To<TravelViewModel>();

            if (package == null)
                return HttpNotFound("Package not found.");

            var data = Mapper.Map<PackageViewModel>(package);
            data.AvailableCategories = categories.CreateSelectListItems(q => q.Name, q => q.Name, q => q.Id == package.Category?.Id);
            data.AvailableContained = containers.CreateSelectListItems(q => q.Name, q => q.Name, q => q.Id == package.ContainedIn?.Id);
            data.AvailableTravel = travels.CreateSelectListItems(q => q.Id.ToString(), q => q.Id.ToString(), q => q.Id == package.Travel?.Id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(PackageViewModel data)
        {
            //if (!ModelState.IsValid)
            //   return View(data);

            var package = _packageRepository.GetById(data.Id);

            if (package == null)
                return HttpNotFound("Package not found.");

            var category = data.CategoryId != null ? _categoryRepository.GetById(data.CategoryId) : null;
            var container = data.ContainedInId != null ? _containerRepository.GetById(data.ContainedInId) : null;
            var travel = data.TravelId != null ? _travelRepository.GetById(data.TravelId) : null;

            package.Update(category, container, travel);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/package
        public ActionResult Index()
        {
            return View(_packageRepository.GetAll().ToList());


        }

        public ActionResult Create()
        {
            var categories = _categoryRepository.GetAll().ToList();
            var containers = _containerRepository.GetAll().ToList();
            var travels = _travelRepository.GetAll().ToList();
            return View(new PackageViewModel
            {
                AvailableCategories = categories.CreateSelectListItems(x => x.Name, x => x.Name, x => false),
                AvailableContained = containers.CreateSelectListItems(x => x.Name, x => x.Name, x => false),
                AvailableTravel = travels.CreateSelectListItems(x => x.Id.ToString(), x => x.Id.ToString(), x => false)
            });
        }

        [HttpPost]
        public ActionResult Create(PackageViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            _packageRepository.Add(new Package
            {
                Category = data.CategoryId != null ? _categoryRepository.GetById(data.CategoryId) : null,
                ContainedIn = data.ContainedInId != null ? _containerRepository.GetById(data.ContainedInId) : null,
                Travel = data.TravelId != null ? _travelRepository.GetById(data.TravelId) : null
            });

            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult Retrieveanswers(string searchTerm, int pageSize, int pageNum)
        {
            var answers = _packageRepository.GetAll();
            var results = answers.Where(c => c.Category.Name.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Category.Name }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}