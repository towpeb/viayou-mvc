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
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITransactionManager _transactionManager;

        public QuestionsController(IQuestionRepository questionRepository, ITransactionManager transactionManager)
        {
            _questionRepository = questionRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _questionRepository.GetById(id);

            if (container == null)
                return HttpNotFound("question not found.");

            return View("Delete", Mapper.Map<QuestionViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _questionRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var question = _questionRepository.GetById(id);
            if (question == null)
                return HttpNotFound("question not found");
            return View(Mapper.Map<QuestionViewModel>(question));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionViewModel data)
        {
            var container = _questionRepository.GetById(data.Id);
            if (container == null)
                return HttpNotFound("question not found.");
            container.Update(data.Text, data.Answers);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/question
        public ActionResult Index()
        {
            return View(_questionRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel data)
        {
            _questionRepository.Add(new Question
            {
                Text = data.Text,
                Answers = data.Answers
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult Retrievequestions(string searchTerm, int pageSize, int pageNum)
        {
            var questions = _questionRepository.GetAll();
            var results = questions.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count(), Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}