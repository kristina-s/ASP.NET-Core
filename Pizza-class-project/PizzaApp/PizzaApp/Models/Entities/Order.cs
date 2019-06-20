using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApp.Models
{
    public class Order :IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCity { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }



    }
}
