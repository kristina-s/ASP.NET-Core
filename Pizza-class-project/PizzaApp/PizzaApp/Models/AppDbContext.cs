using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }

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
