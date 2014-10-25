using System.Data.Entity;
using Core.Models;
using Core.Models.Economy;
using Core.Models.System;

namespace Core.Storage
{
    public class AMFDbContext : DbContext
    {

        public DbSet<Animateur> Animateurs { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mastery> Masteries { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
