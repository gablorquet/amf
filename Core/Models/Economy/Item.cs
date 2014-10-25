using System.Collections.Generic;
using Core.Models.Enums;

namespace Core.Models.Economy
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Bonus> Bonus { get; set; }
        public bool IsPermanent { get; set; }
    }
}
