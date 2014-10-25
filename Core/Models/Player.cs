using System;
using System.Collections.Generic;
using Core.Models.System;

namespace Core.Models
{
    public class Player : User
    {
        public virtual List<Character> Characters { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsResident { get; set; }
        public string PostalCode { get; set; }
        public Contact EmergencyContact { get; set; }

    }
}
