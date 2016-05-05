using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;
using ViaYou.Web.Areas.Admin.Models;

namespace ViaYou.Web.Areas.Admin.Controllers
{
    public class ContainersController : Controller
    {
        private readonly IContainerRepository _containerRepository;
        private readonly ITransactionManager _transactionManager;

        public ContainersController(IContainerRepository containerRepository, ITransactionManager transactionManager)
        {
            _containerRepository = containerRepository;
            _transactionManager = transactionManager;
        }

        // GET: Admin/ContainedIn
        public ActionResult Index()
        {
            return View(_containerRepository.GetAll().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContainerViewModel data)
        {
            _containerRepository.Add(new Container
            {
                Measure = data.Measure,
                Name = data.Name,
                Min = data.Min,
                Max = data.Max
            });
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var container = _containerRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Container not found.");

            return View("Delete", Mapper.Map<ContainerViewModel>(container));
        }
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            _containerRepository.Delete(id);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var container = _containerRepository.GetById(id);

            if (container == null)
                return HttpNotFound("Container not found.");

            return View("Edit", Mapper.Map<ContainerViewModel>(container));
        }
        [HttpPost]
        public ActionResult Edit(ContainerViewModel data)
        {
            var container = _containerRepository.GetById(data.Id);

            if (container == null)
                return HttpNotFound("Container not found.");

            container.Update(data.Name, data.Min, data.Max, data.Measure);
            _transactionManager.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}