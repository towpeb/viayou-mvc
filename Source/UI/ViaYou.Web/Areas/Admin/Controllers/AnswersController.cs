using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Data.Repositories;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ITransactionManager _transactionManager;

        public AnswersController(IAnswerRepository answerRepository, ITransactionManager transactionManager)
        {
            _answerRepository = answerRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _answerRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Answer not found.");

            return View("Delete", Mapper.Map<AnswerViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _answerRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var answer = _answerRepository.GetById(id);
            if (answer == null)
                return HttpNotFound("answer not found");
            return View(Mapper.Map<AnswerViewModel>(answer));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerViewModel data)
        {
            var container = _answerRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("answer not found.");
            container.Update(data.Text, data.Question);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/answer
        public ActionResult Index()
        {
            return View(_answerRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnswerViewModel data)
        {
            _answerRepository.Add(new Answer
            {
                Text = data.Text,
                Question = data.Question
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult Retrieveanswers(string searchTerm, int pageSize, int pageNum)
        {
            var answers = _answerRepository.GetAll();
            var results = answers.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}