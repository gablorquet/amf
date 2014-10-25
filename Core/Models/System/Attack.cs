using Core.Models.Enums;

namespace Core.Models.System
{
    public class Attack : Entity
    {
        public Weapon Weapon { get; set; }
        public int Damage { get; set; }
        public string Attribute { get; set; }
        public string MagicWeapon { get; set; }
    }
}