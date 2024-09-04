using BanqueTardi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BanqueTardi.ContexteDb
{
    public class BanqueTardiContexte : DbContext
    {
        public BanqueTardiContexte(DbContextOptions<BanqueTardiContexte> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<Operation> Operations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<Compte>().ToTable(nameof(Compte));
            modelBuilder.Entity<Operation>().ToTable(nameof(Operation));
        }
    }
}
