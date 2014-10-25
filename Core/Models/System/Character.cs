using System.Collections.Generic;
using Core.Models.Economy;
using Core.Models.Enums;

namespace Core.Models.System
{
    public class Character : Entity
    {
        public int Year { get; set; }
        public string Name { get; set; }
        public virtual Race Race { get; set; }
        public string Religion { get; set; }
        public string AvaliableCategories { get; set; }
        public string Background { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public int Influence { get; set; }
        public int Experience { get; set; }
        public string Title { get; set; }
        public Institution Insitution { get; set; }
        public virtual List<Language> Languages { get; set; }
        public int Destiny { get; set; }
        public virtual Specialization Specialization { get; set; }
        public bool IsPS { get; set; }
        public virtual List<Ressource> RessourcesGenerated { get; set; }
        public int GoldGenerated { get; set; }
        public List<Item> Items { get; set; }

        //Player stats
        public int HitPoints { get; set; }
        public int MinorSpells { get; set; }
        public int MajorSpells { get; set; }
        public virtual List<Attack> Damage { get; set; }
    }
}