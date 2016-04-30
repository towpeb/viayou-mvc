using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViaYou.Domain.Repositories;
using ViaYou.Web.Areas.Admin.Models;
using ViaYou.Web.Helpers;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ITransactionManager _transactionManager;
        private readonly IApplicationUserRepository _userRepository;

        public TestimonialController(ITestimonialRepository testimonialRepository,
                                 IApplicationUserRepository userRepository,
                                 ITransactionManager transactionManager)
        {
            _testimonialRepository = testimonialRepository;
            _userRepository = userRepository;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var container = _testimonialRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Testimonial not found.");

            return View("Delete", Mapper.Map<TestimonialViewModel>(container));
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _testimonialRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var answer = _testimonialRepository.GetById(id);
            var users = _userRepository.GetAll().Project().To<ApplicationUserViewModel>();

            if (answer == null)
                return HttpNotFound("Testimonial not found.");

            var data = Mapper.Map<AnswerViewModel>(answer);
            data.AvailableQuestions = users.CreateSelectListItems(q => q.MiddleName, q => q.MiddleName, q => q.Id == answer.User?.Id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(TestimonialViewModel data)
        {
            //if (!ModelState.IsValid)
            //   return View(data);

            var testimonial = _testimonialRepository.GetById(data.Id);

            if (testimonial == null)
                return HttpNotFound("Testimonial not found.");

            var question = data.User.Id != null ? _userRepository.GetById(data.User.Id) : null;

            testimonial.Update(data.Text, data.Picture, data.User);
            _transactionManager.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/answer
        public ActionResult Index(string term = "")
        {
            return View(_testimonialRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            var users = _userRepository.GetAll().ToList();
            return View(new TestimonialViewModel
            {
                AvailableUsers = users.CreateSelectListItems(x => x.MiddleName, x => x.MiddleName, x => false)
            });
        }

        [HttpPost]
        public ActionResult Create(TestimonialViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            _testimonialRepository.Add(new Domain.Testimonial
            {
                Text = data.Text,
                Picture = data.Picture,
                User = data.User.Id != null ? _userRepository.GetById(data.User.Id) : null
            });

            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult Retrieveanswers(string searchTerm, int pageSize, int pageNum)
        {
            var answers = _testimonialRepository.GetAll();
            var results = answers.Where(c => c.Text.Contains(searchTerm)).Select(c => new { id = c.Id, text = c.Text }).ToList();
            return new JsonResult
            {
                Data = new { Total = results.Count, Results = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}