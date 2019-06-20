using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        //public DbSet<PizzaType> PizzaTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Name = "Peki", City = "Skopje", Address = "23 Oktomvri", Email = "peki@hotmail.com", Phone = "1234567" },
            //    new User { Id = 2, Name = "Angela", City = "Bitola", Address = "Partizanska", Email = "ang@hotmail.com", Phone = "34534567" },
            //    new User { Id = 3, Name = "Jovan", City = "Ohrid", Address = "11 Oktomvri", Email = "joko@hotmail.com", Phone = "1231234" },
            //    new User { Id = 4, Name = "Kalina", City = "Gevgelija", Address = "Ilindenska", Email = "kali@hotmail.com", Phone = "1238765" }
            //    );
            base.OnModelCreating(modelBuilder);

        }
    }
}
