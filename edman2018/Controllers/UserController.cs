using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class UserController : Controller
    {
        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: User
        public ActionResult Index()
        {
            if(Session["UserID"]!=null)
            {
                int ID = int.Parse(Session["UserID"].ToString());
                User user = edmanDBContext.Users.Where(getUser => getUser.User_ID == ID).First();
                List<Order> orders = edmanDBContext.Orders.Where(o => o.User_ID == ID).ToList();
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.user = user;
                userViewModel.Orders = orders;
                return View(userViewModel);
            } else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult EditUser()
        {
            if (Session["UserID"] != null)
            {
                User user = edmanDBContext.Users.Where(getUser => getUser.User_ID == int.Parse(Session["UserID"].ToString())).First();
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            user.Date_Modified = DateTime.Now;
            edmanDBContext.Entry(user).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Order(int id)
        {
            if(Session["Type"]==null || !Session["Type"].ToString().Equals("1"))
            {
                return RedirectToAction("Login", "Home");
            }
            else //if("1".Equals(Session["UserType"].ToString()))
            {
                return View(edmanDBContext.Products.Where(p => p.Product_ID == id).First());
            }
        }

        

        [HttpPost]
        public ActionResult Order(int Product_ID, int Quantity)
        {
            try
            {
                if (edmanDBContext.Inventory.Where(p => p.Product_ID == Product_ID).Select(inv => inv.Quantity).First() > Quantity)
                {
                    addOrder(Product_ID, Quantity, "Pending");
                }
                else
                {
                    addRequest(Product_ID, Quantity);
                }
            } catch (InvalidOperationException e)
            {
                addRequest(Product_ID, Quantity);
            }
            return new RedirectResult(Url.Action("Index") + "#orders");

        }

        public ActionResult MyOrders()
        {
            List<Order> orders = edmanDBContext.Orders.ToList();
            return View(orders);
        }

        public ActionResult Return(int Product_ID)
        {
            Product product = edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).First();
            return View(product);
        }

        [HttpPost]
        public ActionResult Return(Return ret)
        {
            edmanDBContext.Returns.Add(ret);
            edmanDBContext.SaveChanges();
            return RedirectToAction("MyOrders","User");
        }

        public void addOrder(int Product_ID, int Quantity, string Status)
        {
            Order order = new Order();
            

            order.User_ID = int.Parse(Session["UserID"].ToString());
            order.Status = Status;
            order.Date_Ordered = DateTime.Now;

            edmanDBContext.Orders.Add(order);
            edmanDBContext.SaveChanges();

            int ordNo = order.Order_No;
            int pId = Product_ID;
            int q = Quantity;

            decimal price = edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).Select(pr => pr.Price).First();

            decimal total = price * q;

            Order_Details order_Details = new Order_Details{ Order_No = ordNo, Quantity = q, Product_ID = pId, Total = total};

            edmanDBContext.Order_Details.Add(order_Details);
            edmanDBContext.SaveChanges();

        }

        public void addRequest(int Product_ID, int Quantity)
        {
            int userId = int.Parse(Session["UserID"].ToString());
            User currentUser = edmanDBContext.Users.Where(u => u.User_ID == userId).First();
            Request request = new Request();
            request.User_ID = currentUser.User_ID;
            request.First_Name = currentUser.First_Name;
            request.Last_Name = currentUser.Last_Name;
            request.Email = currentUser.Email;
            request.Request_Header = Product_ID.ToString();
            request.Request_Details = Quantity.ToString();
            request.Request_Date = DateTime.Now;

            edmanDBContext.Requests.Add(request);
            edmanDBContext.SaveChanges();

            addOrder(Product_ID, Quantity, "Requesting");

        }

    }
}