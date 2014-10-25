using System.Linq;
using System.Web.Mvc;
using amf.Models;
using Core.Authentication;
using Core.Extensions;
using Core.Models;
using Core.Storage;

namespace amf.Areas.Team.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authentication;
        private readonly ISession _session;

        public HomeController(IAuthenticationService authentication, 
            ISession session)
        {
            _authentication = authentication;
            _session = session;
        }

        public ActionResult Index()
        {
            return WhenLoggedIn();
        }

        public ActionResult Login()
        {
            return _authentication.GetCurrent<Animateur>() != null
                ? WhenLoggedIn() :
                View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (_authentication.GetCurrent<Animateur>() != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var encryptedPassword = model.Password.ToSHA1();

            var animateur = _session.Set<Animateur>()
                .Where(x => x.Username == model.UserName)
                .Where(x => x.Password == encryptedPassword)
                .FirstOrDefault(x => !x.Archived);

            if (animateur == null)
            {
                ModelState.AddModelError("", "Invalid Login info");
                return View();
            }

            _authentication.SetCurrent(animateur);


            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                return Redirect(model.ReturnUrl);

            return RedirectToAction("Index", "Dashboard");

        }


        private ActionResult WhenLoggedIn()
        {
            return RedirectToAction("Index", "Dashboard");
        }

    }
}
