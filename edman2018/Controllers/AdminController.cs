using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class AdminController : Controller
    {

        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            if(Session["Email"]!=null && Session["Type"]!=null)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult ViewAccounts()
        {
            List<User> Employees = edmanDBContext.Users.Where(employee => employee.Type_ID > 2).ToList();
            return View(Employees);
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            edmanDBContext.Users.Add(user);
            edmanDBContext.SaveChanges();
            return RedirectToAction("FinishAccount");
        }

        public ActionResult EditAccount(int User_ID)
        {
            User employee = edmanDBContext.Users.Where(user => user.User_ID == User_ID).First();
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditAccount(User user)
        {
            edmanDBContext.Entry(user).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return RedirectToAction("EditAccount", "Success");
        }

        [HttpDelete]
        public ActionResult DeleteAccount(User user)
        {
            edmanDBContext.Users.Remove(user);
            edmanDBContext.SaveChanges();
            return View("DeleteAccount", "Success");
        }

    }

    
}