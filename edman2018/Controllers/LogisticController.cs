using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class LogisticController : Controller
    {

        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: Logistic
        public ActionResult Index()
        {
            if(Session["UserID"]==null)
            {
                return RedirectToAction("Login", "Home");
            } else
            {
                if(Session["Type"].Equals("2")) {
                    LogisticViewModel logisticViewModel = new LogisticViewModel();
                    logisticViewModel.inventories = edmanDBContext.Inventory.ToList();
                    logisticViewModel.deliveries = edmanDBContext.Deliveries.ToList();
                    logisticViewModel.orders = edmanDBContext.Orders.ToList();
                    return View(logisticViewModel);
                } else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }

        public ActionResult viewInventory()
        {
            List<Inventory> inventories = edmanDBContext.Inventory.ToList();
            return View(inventories);
        }

        public ActionResult AddStocks(int Inventory_ID)
        {
            Inventory inventory = edmanDBContext.Inventory.Where(inv => inv.Inventory_ID == Inventory_ID).First();
            return View(inventory);
        }

        [HttpPost]
        public ActionResult AddStocks(int Inventory_ID, int Quantity)
        {
            Inventory inventory = edmanDBContext.Inventory.Where(inv => inv.Inventory_ID == Inventory_ID).First();
            inventory.Quantity = inventory.Quantity + Quantity;
            edmanDBContext.Entry(inventory).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return new RedirectResult(Url.Action("Index") + "#inventory");
        }

        public ActionResult AddInventory()
        {
            List<int> Product_IDs = edmanDBContext.Products.Select(p => p.Product_ID).ToList();
            List<int> P_ID_inv = edmanDBContext.Inventory.Select(inv => inv.Product_ID).ToList();
            foreach(int pid in P_ID_inv)
            {
                Product_IDs.Remove(pid);
            }
            return View(Product_IDs);
        }

        [HttpPost]
        public ActionResult AddInventory(Inventory inventory)
        {
            string product_name = edmanDBContext.Products.Where(p => p.Product_ID == inventory.Product_ID).Select(pp => pp.Product_Name).First();
            inventory.Quantity = 0;
            inventory.Product_Name = product_name;
            inventory.Inventory_Date = DateTime.Now;
            inventory.Critical_Level = 0;
            edmanDBContext.Inventory.Add(inventory);
            edmanDBContext.SaveChanges();
            return new RedirectResult(Url.Action("Index") + "#inventory");
        }

        public ActionResult viewDelivery()
        {
            List<Delivery> deliveries = edmanDBContext.Deliveries.ToList();
            return View(deliveries);
        }

        public ActionResult viewOrders()
        {
            List<Order> orders = edmanDBContext.Orders.ToList();
            return View(orders);
        }

        public ActionResult viewOrder(Order order)
        {
            return View(order);
        }

    }
}