using System.Collections.Generic;
using Core.Models.Enums;
using Core.Models.System;

namespace Core.Models.Economy
{
    public class Institution : Entity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual List<Character> Members { get; set; }
        public virtual InstitutionType Type { get; set; }
        public virtual Character Leader { get; set; }
        public int Level { get; set; }
    }

    public class InstitutionType : Entity
    {
        public string Name { get; set; }
        public virtual List<List<Bonus>> Bonus { get; set; }
        public virtual List<string> Unlock { get; set; }  
    }
}
