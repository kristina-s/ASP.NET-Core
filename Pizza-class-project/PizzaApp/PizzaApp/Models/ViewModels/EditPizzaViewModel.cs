using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models.ViewModels
{
    public class EditPizzaViewModel :CreatePizzaViewModel
    {
        public int Id { get; set; }
    }
}
