using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class OperationsController : Controller
    {

        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: Operations
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (Session["Type"].Equals("3"))
                {
                    OperationsViewModel operationsViewModel = new OperationsViewModel();
                    operationsViewModel.deliveries = edmanDBContext.Deliveries.ToList();
                    operationsViewModel.orders = edmanDBContext.Orders.ToList();
                    return View(operationsViewModel);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Deliver(int Order_No)
        {
            Order order = edmanDBContext.Orders.Where(o => o.Order_No == Order_No).First();
            order.Status = "Delivering";
            edmanDBContext.Entry(order).State = EntityState.Modified;
            edmanDBContext.SaveChanges();

            Order_Details order_Details = edmanDBContext.Order_Details.SingleOrDefault(od => od.Order_No == Order_No);

            Inventory inventory = edmanDBContext.Inventory.SingleOrDefault(inv => inv.Product_ID == order_Details.Product_ID);
            inventory.Quantity = inventory.Quantity - order_Details.Quantity;
            edmanDBContext.Entry(inventory).State = EntityState.Modified;
            edmanDBContext.SaveChanges();

            Delivery delivery = new Delivery();
            delivery.Date_Delivered = DateTime.Now;
            delivery.Delivery_Address = edmanDBContext.Users.Where(u => u.User_ID == order.User_ID).Select(us => us.Address).First();
            delivery.Status = "Delivering";

            edmanDBContext.Deliveries.Add(delivery);
            edmanDBContext.SaveChanges();

            return new RedirectResult(Url.Action("Index") + "#delivery");
        }

        public ActionResult FinishDelivery(int Delivery_No)
        {
            Delivery delivery = edmanDBContext.Deliveries.Where(d => d.Delivery_No == Delivery_No).First();
            delivery.Status = "Delivered";
            edmanDBContext.Entry(delivery).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return new RedirectResult(Url.Action("Index") + "#delivery");
        }

        public ActionResult viewAllProducts()
        {
            List<Product> products = edmanDBContext.Products.ToList();
            return View(products);
        }

        public ActionResult viewProduct(int Product_ID)
        {
            Product product = edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).First();
            return View(product);
        }

        public ActionResult addComment(Review review)
        {
            edmanDBContext.Reviews.Add(review);
            return viewProduct(review.Product_ID);
        }

        /**
         TODO: 

        View Delivery
        View Orders
        Edit Orders
         
         */

        public ActionResult viewDelivery()
        {
            List<Delivery> deliveries = edmanDBContext.Deliveries.ToList();
            return View(deliveries);
        }

        public ActionResult viewOrder(int Order_No)
        {
            Order order = edmanDBContext.Orders.Where(o => o.Order_No == Order_No).First();
            return View(order);
        }

        public ActionResult editOrder(int Order_No)
        {
            Order order = edmanDBContext.Orders.Where(o => o.Order_No == Order_No).First();
            return View(order);
        }

        [HttpPost]
        public ActionResult editOrder(Order order)
        {
            edmanDBContext.Entry(order).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return RedirectToAction("editOrder","Success");
        }

    }
}