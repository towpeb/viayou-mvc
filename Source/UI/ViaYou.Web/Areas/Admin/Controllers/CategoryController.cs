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
    public class CategoryController : Controller
    {
        ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("delete/category/{id}")]
        public ActionResult Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryRepository.GetById(id);
            return View(new CategoryViewModel() { Name=category.Name } );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel data)
        {
            _categoryRepository.Update(id, data.Name);
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
            if (!ModelState.IsValid)
                return View(data);

            _categoryRepository.Add(new Category(data.Name));
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveCategories(string searchTerm, int pageSize, int pageNum)
        {
            var cities = _categoryRepository.GetAll();
            var results = cities.Where(c => c.Name.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Name }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}