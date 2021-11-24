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
   

    public class JobController : Controller
    {
        private JobService CreateJobServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }
        // GET: Job
        public ActionResult Index()
        {
            var service = CreateJobServices();

            var model = service.GetJobs();
            return View(model.ToList());
        }
        //Get: Job/Create
        public ActionResult Create()

        {
            return View();
        }
        //Post: Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobServices();
            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Employer created successfully";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Employer could not be created");
            return View(model);
        }




        public ActionResult Details(int id)
        {
            var svc = CreateJobServices();
            var model = svc.GetJobById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateJobServices();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    Id = detail.Id,
                    JobTitle = detail.JobTitle,
                    JobDescription = detail.JobDescription,
                    Location =detail.Location
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateJobServices();
            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Job was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Job could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobServices();
            var model = svc.GetJobById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobServices();
            service.DeleteJob(id);
            TempData["SaveResult"] = "Job was delected successfully";
            return RedirectToAction("Index");
        }
    }

}
