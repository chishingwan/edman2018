using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    public class EdmanDBContext : DbContext
    {

        public EdmanDBContext()
        {

        }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Payment_Method> Payment_Methods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Details> Product_Details { get; set; }
        public DbSet<Releasing> Releasing { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Sales_Details> Sales_Details { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<U_Type> User_Types { get; set; }
        
    }
}