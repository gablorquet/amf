using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Extensions;
using Core.Models;

namespace amf.Controllers
{
    public class CiController : Controller
    {
        public string Index()
        {
            var bass = new Animateur
            {
                Email = "bass.lavoie@gmail.com",
                Name = "Bass Lavoie",
                Password = "patate".ToSHA1(),
                Username = "The_Bass"
            };

            return "Done";
        }

    }
}
