using System.Web.Mvc;
using Core.Storage;

namespace amf.Areas.Team.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ISession _session;

        public DashboardController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
