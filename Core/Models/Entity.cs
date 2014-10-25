using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Archived { get; set; }

        protected Entity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }

}
