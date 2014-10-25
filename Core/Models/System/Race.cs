using System.Collections.Generic;
using Core.Models.Enums;

namespace Core.Models.System
{
    public class Race : Entity
    {
        public string Name { get; set; }
        public virtual List<Skill> RacialSkills { get; set; }
        public virtual Language Language { get; set; }
    }
}