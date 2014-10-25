using System.Collections.Generic;
using Core.Models.Enums;

namespace Core.Models.System
{
    public class Skill : Entity
    {
        public string Name { get; set; }
        public virtual List<Keyword> Keywords { get; set; } 
        public string Description { get; set; }
        public string Target { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public string Limitation { get; set; }
        public bool IsSpell { get; set; }
        public Race Racial { get; set; }
        public Category RacialPreReq { get; set; }
        public virtual List<Category> Categories { get; set; }
        public bool IsPassive { get; set; }
        public bool IsPassive2 { get; set; }
        public List<Skill> PreReq { get; set; }


        //For calculating bonus purposes
        public virtual List<Bonus> Bonus { get; set; }
        public virtual List<Mastery> Masteries { get; set; } 

    }
}
