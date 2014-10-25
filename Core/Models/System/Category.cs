using System.Collections.Generic;

namespace Core.Models.System
{
    public class Category : Entity
    {
        public virtual List<Skill> Skills { get; set; }
        public virtual List<Skill> Passives { get; set; }
        public virtual List<Skill> Experience { get; set; }
    }
}