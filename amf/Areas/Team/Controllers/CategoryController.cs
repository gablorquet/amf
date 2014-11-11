using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using amf.Areas.Team.Models;
using amf.Extensions;
using Core.Models.System;
using Core.Storage;
using Microsoft.Ajax.Utilities;

namespace amf.Areas.Team.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ISession _session;

        public CategoryController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            var categories = _session.Set<Category>()
                .Where(x => x.Archived != true)
                .ToList();

            var model = new CategoryIndexModel(categories);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var category = _session.SingleById<Category>(id);

            if (category == null)
                return HttpNotFound();

            var model = new CategoryModel(category);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _session.SingleById<Category>(id);

            if (category == null)
                return HttpNotFound();

            var model = new CategoryModel(category);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = _session.SingleById<Category>(model.Id);

            if (category == null)
                return HttpNotFound();

            category.UpdateFrom(model);

            try
            {
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception();            
            }

            return RedirectToAction("Details", new {id = model.Id});
        }

        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        public ActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var category = model.AsCategory();

            try
            {
                _session.Add(category);
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
