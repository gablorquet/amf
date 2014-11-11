using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using amf.Extensions;
using amf.Models;
using Core.Models;
using Core.Storage;

namespace amf.Areas.Team.Controllers
{
    public class UserControllerController : Controller
    {
        private readonly ISession _session;

        public UserControllerController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var user = _session.SingleById<User>(id);

            if (user == null)
                return HttpNotFound();

            var model = new UserModel(user);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var user = _session.SingleById<User>(id);

            if (user == null)
                return HttpNotFound();

            var model = new UserModel(user);

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _session.SingleById<User>(model.Id);

            if (user == null)
                return HttpNotFound();

            user.UpdateFrom(model);

            try
            {
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return RedirectToAction("Details", new {id = user.Id});
        }

        public ActionResult Create()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = model.AsUser();

            try
            {
                _session.Add(user);
                _session.Commit();
            }
            catch (Exception)
            {
                throw new Exception("Placeholder");
            }

            return RedirectToAction("Details", new {id = user.Id});
        }

        
    }
}
