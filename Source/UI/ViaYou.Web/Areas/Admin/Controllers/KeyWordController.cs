using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class KeyWordController : Controller
    {
        private readonly IKeyWordRepository _keywordRepository;
        private readonly ITransactionManager _transactionManager;

        public KeyWordController(IKeyWordRepository keywordRepository, ITransactionManager transactionManager)
        {
            _keywordRepository = keywordRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _keywordRepository.GetById(id);

            if (container == null)
                return HttpNotFound("KeyWord not found.");

            return View("Delete", Mapper.Map<KeyWordViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _keywordRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var advice = _keywordRepository.GetById(id);
            if (advice == null)
                return HttpNotFound("KeyWord not found");
            return View(Mapper.Map<KeyWordViewModel>(advice));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KeyWordViewModel data)
        {
            var container = _keywordRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("KeyWord not found.");
            container.Update(data.Keywords, data.Description, data.FacebookMsg, data.FacebookImg, data.TwitterMsg, data.TwitterImg, data.Active);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/KeyWord
        public ActionResult Index()
        {
            return View(_keywordRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KeyWordViewModel data)
        {
            _keywordRepository.Add(new KeyWord
            {
                Keywords = data.Keywords,
                Description = data.Description,
                FacebookMsg = data.FacebookMsg,
                FacebookImg = data.FacebookImg,
                TwitterMsg = data.TwitterMsg,
                TwitterImg = data.TwitterImg,
                Active = data.Active,
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveAdvices(string searchTerm, int pageSize, int pageNum)
        {
            var advices = _keywordRepository.GetAll();
            var results = advices.Where(c => c.Keywords.Contains(searchTerm)).Select(c => new { id = c.Id, keyword = c.Keywords }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}