using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using ViaYou.Domain;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;
using ViaYou.Web.Helpers;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ITransactionManager _transactionManager;

        public QuestionsController(IQuestionRepository questionRepository,
                                   IAnswerRepository answerRepository,
                                   ITransactionManager transactionManager)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
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

        public ActionResult Edit(int id)
        {
            var question = _questionRepository.GetById(id);
            var answers = _answerRepository.GetAll().ToList();

            if (question == null)
                return HttpNotFound("question not found");

            var data = Mapper.Map<QuestionViewModel>(question);
            data.SelectedAnswersIds = question.Answers.Select(a => a.Id).ToList();
            data.AvailableAnswers = answers.CreateSelectListItems(a => a.Text, a => a.Id.ToString(), a=>data.SelectedAnswersIds.Contains(a.Id));

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionViewModel data)
        {
            var question = _questionRepository.GetById(data.Id);

            if (question == null)
                return HttpNotFound("question not found.");

            var toDelete = question.Answers.Where(a => !data.SelectedAnswersIds.Contains(a.Id)).ToList();
            foreach (var answer in toDelete)
                question.DropAnswer(answer);

            var toAdd = data.SelectedAnswersIds.Where(a => question.Answers.All(x => x.Id != a));
            foreach (var id in toAdd)
                question.AddAnswer(_answerRepository.GetById(id));
            
            question.Update(data.Identifier, data.Text);
            
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
            var answers = _answerRepository.GetAll().ToList();
            return View(new QuestionViewModel
            {
                AvailableAnswers = answers.CreateSelectListItems(a => a.Text, a => a.Id.ToString()),
            });
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            var newQuestion = new Question
            {
                Text = data.Text,
                Identifier = data.Identifier
            };

            foreach (var id in data.SelectedAnswersIds)
                newQuestion.AddAnswer(_answerRepository.GetById(id));

            _questionRepository.Add(newQuestion);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult RetrieveQuestions(string searchTerm, int pageSize, int pageNum)
        {
            var questions = _questionRepository.GetAll();
            var results = questions.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}