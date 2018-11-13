using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class HomeController : Controller
    {
        EdmanDBContext edmanDBContext = new EdmanDBContext();
        // GET: Home
        public ActionResult Index()
        {
            if(Session["Type"]==null)
            {
                return View(edmanDBContext.Products.ToList());
            } else { 
                switch (Session["Type"])
                {
                    case "1":
                        return View(edmanDBContext.Products.ToList());

                    case null:
                        return View(edmanDBContext.Products.ToList());

                    case "0": // Administrator
                        return RedirectToAction("Index", "Admin");

                    case "2": // Logistic Clerk
                        return RedirectToAction("Index", "Logistic");

                    case "3": // Operations Manager
                        return RedirectToAction("Index", "Operations");

                    case "4": // Accounting
                        return RedirectToAction("Index", "Accounting");

                    case "5": // Sales Clerk
                        return RedirectToAction("Index", "Sales");

                    case "6": // International Correspondence & Secretary
                        return RedirectToAction("Index", "ICS");

                    default:
                        return RedirectToAction("Restricted", "Failed");

                }
                
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Type_ID = 1;
            user.Date_Added = DateTime.Now;
            user.Date_Modified = DateTime.Now;
            edmanDBContext.Users.Add(user);
            edmanDBContext.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (edmanDBContext)
                {
                    var userIn = edmanDBContext.Users.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (userIn != null)
                    {
                        Session["UserID"] = userIn.User_ID;
                        Session["Email"] = userIn.Email;
                        Session["Type"] = userIn.Type_ID.ToString();
                        switch (Session["Type"].ToString())
                        {
                            case "0": // Administrator
                                return RedirectToAction("Index", "Admin");

                            case "2": // Logistic Clerk
                                return RedirectToAction("Index", "Logistic");

                            case "3": // Operations Manager
                                return RedirectToAction("Index", "Operations");

                            case "4": // Accounting
                                return RedirectToAction("Index", "Accounting");

                            case "5": // Sales Clerk
                                return RedirectToAction("Index", "Sales");

                            case "6": // International Correspondence & Secretary
                                return RedirectToAction("Index", "ICS");

                            default: // Customer
                                return RedirectToAction("Index", "Home");

                        }
                    }
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public ActionResult ViewProduct(int id)
        { 
            switch(Session["Type"])
            {
                case "1":
                    return View(edmanDBContext.Products.Where(product => product.Product_ID == id).First());

                case null:
                    return View(edmanDBContext.Products.Where(product => product.Product_ID == id).First());

                default:
                    return RedirectToAction("Restricted","Failed");
                    
            }
        }

    }
}