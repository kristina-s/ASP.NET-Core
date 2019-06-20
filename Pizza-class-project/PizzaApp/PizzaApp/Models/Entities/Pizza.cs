using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Pizza : IEntity
    {
        public string Name { get; set; }
        public int PizzaTypeId { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

        public virtual PizzaType PizzaType {get; set;}
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
