using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsNew()
        {
            return Id == 0;
        }

        protected Entity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }

}
