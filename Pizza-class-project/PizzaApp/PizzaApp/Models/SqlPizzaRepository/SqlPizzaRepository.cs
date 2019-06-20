using PizzaApp.Models.IRepositories;
using PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.SqlPizzaRepository
{
    public class SqlPizzaRepository : IPizzaRepository
    {
        private PizzaDbContext db;
        public SqlPizzaRepository(PizzaDbContext context)
        {
            db = context;
        }
        public Pizza Add(Pizza pizza)
        {
            //int nextId = db.Pizza.Count() + 1;
            //pizza.Id = nextId;
            db.Pizza.Add(pizza);
            db.SaveChanges();
            return pizza;
        }

        public Pizza Delete(int id)
        {
            Pizza pizza = db.Pizza.Find(id);
            db.Pizza.Remove(pizza);
            db.SaveChanges();
            return pizza;
        }

        public Pizza Get(int id)
        {
            return db.Pizza.Find(id);
        }

        public IEnumerable<Pizza> GetAll()
        {
            return db.Pizza;
        }

        public Pizza Update(Pizza newPizza)
        {
            Pizza pizza = db.Pizza.FirstOrDefault(x => x.Id == newPizza.Id);
            if(pizza != null)
            {
                pizza.Name = newPizza.Name;
                pizza.PizzaTypeId = newPizza.PizzaTypeId;
                pizza.Size = newPizza.Size;
                pizza.Price = newPizza.Price;
            }        
            db.SaveChanges();
            return pizza;
        }
    }
}
