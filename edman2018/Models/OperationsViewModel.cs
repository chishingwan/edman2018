using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    public class OperationsViewModel
    {
        public List<Order> orders { get; set; }
        public List<Delivery> deliveries { get; set; }
    }
}