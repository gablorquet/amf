using System.Collections.Generic;
using Core.Models.Enums;

namespace Core.Models.System
{
    public class Specialization : Entity
    {
        public virtual List<Skill> Skills { get; set; }
        public virtual List<Keyword> PreReq { get; set; } 
    }
}