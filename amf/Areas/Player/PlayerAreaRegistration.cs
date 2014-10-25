﻿using System.Web.Mvc;

namespace amf.Areas.Player
{
    public class PlayerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Player";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Player_default",
                "Player/{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "amf.Areas.Player.Controllers" });
        }
    }
}
