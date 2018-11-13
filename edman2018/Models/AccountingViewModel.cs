using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    public class AccountingViewModel
    {

        public class TReturns
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public int Total_Returns { get; set; }
        }

        public class TOrders
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public int Total_Orders { get; set; }
        }

        public class TReviews
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public int Total_Reviews { get; set; }
        }

        public class TRequests
        {
            public int Product_ID { get; set; }
            public string Product_Name { get; set; }
            public int Total_Requests { get; set; }
        }

        public class TLocation
        {
            public string Location { get; set; }
            public int Total_Deliveries { get; set; }
        }

        public List<Product> TopReturn { get; set; }
        public List<TOrders> TopOrder  { get; set; }
        public List<Product> TopReview { get; set; }
        public List<Product> TopRequest { get; set; }
        public List<Order> TopLocation { get; set; }

        public List<Sales> sales { get; set; }
        public List<Delivery> deliveries { get; set; }
        public List<Return> returns { get; set; }
        public List<Request> requests { get; set; }
    }
}