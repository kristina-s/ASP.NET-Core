using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class PizzaType : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
