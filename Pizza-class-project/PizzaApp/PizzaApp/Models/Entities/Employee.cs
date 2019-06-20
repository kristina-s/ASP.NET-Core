using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Employee : IEntity
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
