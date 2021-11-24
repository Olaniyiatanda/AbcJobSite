using AbcJobsite.Services;
using AbcJobSite.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbcJobSite.MVC.Controllers
{
    [Authorize]
    public class EmployerController : Controller
    {
        private EmployerService CreateEmployerServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployerService(userId);
            return service;
        }
        // GET: Employer
        public ActionResult Index()
        {
            var service = CreateEmployerServices();
       
            var model = service.GetEmployers();
                return View(model.ToList());
        }
        //Get: Employer/Create
        public ActionResult Create()
        
        {
            return View();
        }

        //Post: Employer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateEmployerServices();
            if (service.CreateEmployer(model))
            {
                TempData["SaveResult"] = "Employer created successfully";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Employer could not be created");
            return View(model);
        }

       
        public ActionResult Details(int id)
        {
            var svc = CreateEmployerServices();
            var model = svc.GetEmployerById(id);
            return View(model);
        }
        public ActionResult Edit (int id)
        {
            var service = CreateEmployerServices();
            var detail = service.GetEmployerById(id);
            var model =
                new EmployerEdit
                {
                    Id = detail.Id,
                    EmployerName = detail.EmployerName,
                    EmployerEmail = detail.EmployerEmail,
                    EmployerAddress = detail.EmployerAddress,
                    City = detail.City,
                    State = detail.State
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateEmployerServices();
            if (service.UpdateEmployer(model))
            {
                TempData["SaveResult"] = "Employer was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Employer could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEmployerServices();
            var model = svc.GetEmployerById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmployerServices();
            service.DeleteEmployer(id);
            TempData["SaveResult"] = "Employer was delected successfully";
            return RedirectToAction("Index");
        }
    }
}