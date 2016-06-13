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
    public class HTMLContentController: Controller
    {
        private readonly IHTMLContentRepository _htmlcontentRepository;
        private readonly ITransactionManager _transactionManager;

        public HTMLContentController(IHTMLContentRepository htmlcontentRepository, ITransactionManager transactionManager)
        {
            _htmlcontentRepository = htmlcontentRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _htmlcontentRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Advice not found.");

            return View("Delete", Mapper.Map<HTMLContentViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _htmlcontentRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var advice = _htmlcontentRepository.GetById(id);
            if (advice == null)
                return HttpNotFound("Advice not found");
            return View(Mapper.Map<HTMLContentViewModel>(advice));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HTMLContentViewModel data)
        {
            var container = _htmlcontentRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("HTMLContent not found.");
            container.Update(data.Text, data.Region, data.Order);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/HTMLContent
        public ActionResult Index()
        {
            return View(_htmlcontentRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HTMLContentViewModel data)
        {
            _htmlcontentRepository.Add(new HTMLContent
            {
                Text = data.Text,
                Region = data.Region,
                Order = data.Order
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveAdvices(string searchTerm, int pageSize, int pageNum)
        {
            var advices = _htmlcontentRepository.GetAll();
            var results = advices.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}