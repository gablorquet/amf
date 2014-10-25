using System.Collections.Generic;
using Core.Models.Enums;

namespace Core.Models.System
{
    public class Mastery : Entity
    {
        public Skill SkillAffected { get; set; }
        public virtual List<Bonus> Bonuses { get; set; }
    }
}