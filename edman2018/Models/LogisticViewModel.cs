using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    public class LogisticViewModel
    {
        public List<Inventory> inventories { get; set; }
        public List<Delivery> deliveries { get; set; }
        public List<Order> orders { get; set; }
    }
}