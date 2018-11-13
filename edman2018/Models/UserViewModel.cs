using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    public class UserViewModel
    {
        public User user { get; set; }
        public List<Order> Orders { get; set; }
    }
}