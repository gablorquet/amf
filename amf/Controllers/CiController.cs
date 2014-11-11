using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core.Extensions;
using Core.Models;
using Core.Models.System;
using Core.Storage;

namespace amf.Controllers
{
    public class CiController : Controller
    {
        private readonly ISession _session;

        public CiController(ISession session)
        {
            _session = session;
        }


        public string Index()
        {
            Seed();

            return "Done";
        }

        public void Seed()
        {
            SeedUser();
            SeedCategories();
            SeedSkills();
            SeedCharacter();
        }

        private void SeedCharacter()
        {
        }

        private void SeedSkills()
        {
        }

        private void SeedCategories()
        {
            var martial = new Category
            {
                Name = "Martial",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };
            var rogue = new Category
            {
                Name = "Roublardise",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };
            var hunter = new Category
            {
                Name = "Chasseur",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };
            var mage = new Category
            {
                Name = "Arcane",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };
            var divine = new Category
            {
                Name = "Divin",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };
            var natural = new Category
            {
                Name = "Naturel",
                Experience = new List<Skill>(),
                Skills = new List<Skill>(),
                Passives = new List<Skill>()
            };

            _session.Add(martial);
            _session.Add(rogue);
            _session.Add(hunter);
            _session.Add(mage);
            _session.Add(divine);
            _session.Add(natural);

            _session.Commit();

        }

        private void SeedUser()
        {
            var animateur = new Animateur
            {
                Email = "gablorquet@hotmail.com",
                Name = "Gabriel Lorquet",
                Username = "GabLork",
                Password = "Password1".ToSHA1()
            };

            _session.Add(animateur);

            var contact = new Contact
            {
                Name = "Mom",
                PhoneHome = "5555555555",
                RelationToUser = "Mother"
            };
            _session.Add(contact);

            var player = new Player
            {
                Email = "gablorquet@gmail.com",
                Name = "Gab Lorquet",
                Username = "GabLorkPlayer",
                Password = "Password1".ToSHA1(),
                EmergencyContact = contact,
                Birthday = new DateTime(1986,01,29)
            };
            _session.Add(player);


            _session.Commit();
        }
    }
}
