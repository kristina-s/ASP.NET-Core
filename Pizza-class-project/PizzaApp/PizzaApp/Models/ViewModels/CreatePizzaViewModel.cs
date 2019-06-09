using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; }
        public int PizzaTypeId { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

    }
}
