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
    public class SkillController : Controller
    {
        private SkillService CreateSkillServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SkillService(userId);
            return service;
        }
        // GET: Skill
        public ActionResult Index()
        {
            var service = CreateSkillServices();

            var model = service.GetSkills();
            return View(model.ToList());
        }
        //Get: Skill/Create
        public ActionResult Create()

        {
            return View();
        }

        //Post: Skill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSkillServices();
            if (service.CreateSkill(model))
            {
                TempData["SaveResult"] = "Skill created successfully";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Skill could not be created");
            return View(model);
        }


        public ActionResult Details(int id)
        {
            var svc = CreateSkillServices();
            var model = svc.GetSkillById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateSkillServices();
            var detail = service.GetSkillById(id);
            var model =
                new SkillEdit
                {
                    Id = detail.Id,
                    SkillName = detail.SkillName,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SkillEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSkillServices();
            if (service.UpdateSkill(model))
            {
                TempData["SaveResult"] = "Skill was updated successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Skill could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSkillServices();
            var model = svc.GetSkillById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSkillServices();
            service.DeleteSkill(id);
            TempData["SaveResult"] = "Skill was delected successfully";
            return RedirectToAction("Index");

        }
    }
}