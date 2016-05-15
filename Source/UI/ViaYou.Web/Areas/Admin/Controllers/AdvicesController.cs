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
    public class AdvicesController : Controller
    {
        private readonly IAdviceRepository _adviceRepository;
        private readonly ITransactionManager _transactionManager;

        public AdvicesController(IAdviceRepository adviceRepository, ITransactionManager transactionManager)
        {
            _adviceRepository = adviceRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _adviceRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Advice not found.");

            return View("Delete", Mapper.Map<AdviceViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _adviceRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var advice = _adviceRepository.GetById(id);
            if (advice == null)
                return HttpNotFound("Advice not found");
            return View(Mapper.Map<AdviceViewModel>(advice));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdviceViewModel data)
        {
            var container = _adviceRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("Advice not found.");
            container.Update(data.Text, data.Customer);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/advice
        public ActionResult Index()
        {
            return View(_adviceRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdviceViewModel data)
        {
            _adviceRepository.Add(new Advice
            {
                Text = data.Text,
                Customer = data.Customer
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveAdvices(string searchTerm, int pageSize, int pageNum)
        {
            var advices = _adviceRepository.GetAll();
            var results = advices.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}