using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using amf.Areas.Team.Models;
using amf.Extensions;
using Core.Models.System;
using Core.Storage;

namespace amf.Areas.Team.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISession _session;

        public SkillController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var skill = _session.SingleById<Skill>(id);

            if (skill == null)
                return HttpNotFound();

            var model = new SkillModel(skill);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var skill = _session.SingleById<Skill>(id);

            if (skill == null)
                return HttpNotFound();

            var model = new SkillModel(skill);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SkillModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var skill = _session.SingleById<Skill>(model.Id);

            if (skill == null)
                return HttpNotFound();

            skill.UpdateFrom(model);

            try
            {
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Placeholder");
            }

            return RedirectToAction("Details", new {id = model.Id});
        }

        public ActionResult Create()
        {
            return View(new SkillModel());
        }

        public ActionResult Create(SkillModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var skill = model.AsSkill();

            try
            {
                _session.Add(skill);
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Placeholder");
            }

            return RedirectToAction("Details", new {id = skill.Id});
        }

        public ActionResult GetSkillsForCategory(int id)
        {
            var category = _session.SingleById<Category>(id);

            if (category == null)
                return HttpNotFound();

            var model = _session.Set<Skill>()
                .Where(x => x.Categories.Any(y => y.Id == category.Id))
                .ToList()
                .Select(x => new SkillModel(x))
                .ToList();

            return View(model);
        }
    }
}
