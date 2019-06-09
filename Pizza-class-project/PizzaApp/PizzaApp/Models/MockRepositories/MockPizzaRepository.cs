using PizzaApp.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.MockRepositories
{
    public class MockPizzaRepository : IPizzaRepository
    {
        List<Pizza> pizzas;
        public MockPizzaRepository()
        {
            pizzas = new List<Pizza>()
            {
                new Pizza {Id=1, Name="Capriciosa", PizzaTypeId=1, Size=Size.small, Price=150},
                new Pizza {Id=2, Name="Quatro Staggione", PizzaTypeId=2, Size=Size.medium, Price=250},
                new Pizza {Id=3, Name="Vegetariana", PizzaTypeId=3, Size=Size.large, Price=450}
            };
        }
        //Create
        public Pizza Add(Pizza pizza)
        {
            int nextId = pizzas.Max(p => p.Id) + 1;
            pizza.Id = nextId;
            pizzas.Add(pizza);
            return pizza;
        }

        public Pizza Delete(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(x => x.Id == id);
            pizzas.Remove(pizza);
            return pizza;
        }

        public Pizza Get(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(x => x.Id == id);
            return pizza;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return pizzas;
        }

        public Pizza Update(Pizza pizzaChanges)
        {
            Pizza pizza = pizzas.FirstOrDefault(x => x.Id == pizzaChanges.Id);
            if(pizza != null)
            {
                pizza.Name = pizzaChanges.Name;
                pizza.PizzaType = pizzaChanges.PizzaType;
                pizza.Price = pizzaChanges.Price;
                pizza.Size = pizzaChanges.Size;
            }
            return pizza;
        }
    }
}
