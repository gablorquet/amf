using System.Web.Mvc;

namespace amf.Areas.Team
{
    public class TeamAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Team";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Team_default",
                "Team/{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "amf.Areas.Team.Controllers" });
        }
    }
}
