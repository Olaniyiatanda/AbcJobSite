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
    public class JobApplicationController : Controller
    {
        private JobApplicationService CreateJobApplicationServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobApplicationService(userId);
            return service;
        }
        // GET: JobApplication
        public ActionResult Index()
        {
            var service = CreateJobApplicationServices();

            var model = service.GetJobApplications();
            return View(model.ToList());
        }
        //Get: JobApplication/Create
        public ActionResult Create()

        {
            return View();
        }

        //Post: JobApplication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobApplicationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobApplicationServices();
            if (service.CreateJobApplication(model))
            {
                TempData["SaveResult"] = "JobApplication created successfully";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "JobApplication could not be created");
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var svc = CreateJobApplicationServices();
            var model = svc.GetJobApplicationById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateJobApplicationServices();
            var detail = service.GetJobApplicationById(id);
            var model =
                new JobApplicationEdit
                {
                    Id = detail.Id,
                    ApplicantId = detail.ApplicantId,
                   
                    JobId = detail.JobId,
                    DateTimeNow = detail.DateTimeNow
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobApplicationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateJobApplicationServices();
            if (service.UpdateJobApplication(model))
            {
                TempData["SaveResult"] = "JobApplication was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "JobApplication could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobApplicationServices();
            var model = svc.GetJobApplicationById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobApplicationServices();

            service.DeleteJobApplication(id);
            TempData["SaveResult"] = "JobApplication was delected successfully";
            return RedirectToAction("Index");
        }
    }

}
