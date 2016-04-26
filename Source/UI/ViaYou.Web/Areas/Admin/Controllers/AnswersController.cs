using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;
using ViaYou.Web.Helpers;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ITransactionManager _transactionManager;
        private readonly IQuestionRepository _questionRepository;

        public AnswersController(IAnswerRepository answerRepository,
                                 IQuestionRepository questionRepository,
                                 ITransactionManager transactionManager)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
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

        public ActionResult Edit(int id)
        {
            var answer = _answerRepository.GetById(id);
            var questions = _questionRepository.GetAll().Project().To<QuestionViewModel>();

            if (answer == null)
                return HttpNotFound("Answer not found.");

            var data = Mapper.Map<AnswerViewModel>(answer);
            data.AvailableQuestions = questions.CreateSelectListItems(q => q.Identifier, q => q.Text, q=>q.Id == answer.Question?.Id);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            var answer = _answerRepository.GetById(data.Id);

            if (answer == null)
                return HttpNotFound("Answer not found.");

            answer.Update(data.Text, data.QuestionId != null ? _questionRepository.GetById(data.QuestionId.Value) : null);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/answer
        public ActionResult Index(string term="")
        {
            return View(_answerRepository.GetAll()
                .ToList()
                .Where(a => a.Terms()
                    .Any(t => t.Contains(term))));
        }

        public ActionResult Create()
        {
            var questions = _questionRepository.GetAll().ToList();
            return View(new AnswerViewModel
            {
                AvailableQuestions = questions.CreateSelectListItems(x => x.Identifier, x => x.Id.ToString(), x=>false)
            });
        }

        [HttpPost]
        public ActionResult Create(AnswerViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            _answerRepository.Add(new Answer
            {
                Text = data.Text,
                Question = data.QuestionId != null ? _questionRepository.GetById(data.QuestionId.Value) : null
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
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}