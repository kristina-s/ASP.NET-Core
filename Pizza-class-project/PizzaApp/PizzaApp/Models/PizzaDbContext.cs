using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizza { get; set; }

        public DbSet<PizzaType> PizzaType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaType>().HasData(
                new PizzaType { Id = 1, Name = "Capri", Description = "dough, ham, mashrums" },
                new PizzaType { Id = 2, Name = "Quatro", Description = "dough, cheese, mashrums" },
                new PizzaType { Id = 3, Name = "Vege", Description = "dough, vegetables, mashrums" }
                );
            base.OnModelCreating(modelBuilder);


        }
    }
}
