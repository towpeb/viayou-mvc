using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionManager _transactionManager;

        public CategoriesController(ICategoryRepository categoryRepository, ITransactionManager transactionManager)
        {
            _categoryRepository = categoryRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _categoryRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Category not found.");

            return View("Delete", Mapper.Map<CategoryViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _categoryRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
                return HttpNotFound("Category not found");
            return View(Mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel data)
        {
            var container = _categoryRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("Category not found.");
            container.Update(data.Name);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel data)
        {
            _categoryRepository.Add(new Category
            {
                Name = data.Name,
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveCategories(string searchTerm, int pageSize, int pageNum)
        {
            var categories = _categoryRepository.GetAll();
            var results = categories.Where(c => c.Name.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Name }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}