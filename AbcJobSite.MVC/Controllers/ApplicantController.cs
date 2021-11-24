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
    public class ApplicantController : Controller
    {

     
        private ApplicantService CreateApplicantServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplicantService(userId);
            return service;
        }
        // GET: Applicant 
        public ActionResult Index()
        {
            var service = CreateApplicantServices();

            var model = service.GetApplicants();
            return View(model);
        }
        //Get: Applicant/Create
        public ActionResult Create()

        {
            return View();
        }

        //Post: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicantCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateApplicantServices();
            if (service.CreateApplicant(model))
            {
                TempData["SaveResult"] = "Applicant created successfully";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Applicant could not be created");
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var svc = CreateApplicantServices();
            var model = svc.GetApplicantById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateApplicantServices();
            var detail = service.GetApplicantById(id);
            var model =
                new ApplicantEdit
                {
                    Id = detail.Id,
                    ApplicantName = detail.ApplicantName,
                    ApplicantEmail = detail.ApplicantEmail,
                    PhoneNumber = detail.PhoneNumber,
                    Location = detail.Location,
                    Address = detail.Address,
                    CreatedUtc = detail.CreatedUtc
                 
                };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, ApplicantEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateApplicantServices();
            if (service.UpdateApplicant(model))
            {
                TempData["SaveResult"] = "Applicant was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Applicant could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateApplicantServices();
            var model = svc.GetApplicantById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateApplicantServices();
            service.DeleteApplicant(id);
            TempData["SaveResult"] = "Applicant was delected";
            return RedirectToAction("Index");
        }
    }
}
