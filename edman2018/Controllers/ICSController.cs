using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class ICSController : Controller
    {

        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: ICS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewInventory()
        {
            List<Inventory> inventories = edmanDBContext.Inventory.ToList();
            return View(inventories);
        }

        /**
         
        View, Edit Request

        View Return
         
         */

        public ActionResult viewRequests()
        {
            List<Request> requests = edmanDBContext.Requests.ToList();
            return View(requests);
        }

        public ActionResult editRequest(int Request_ID)
        {
            Request request = edmanDBContext.Requests.Where(r => r.Request_ID == Request_ID).First();
            return View(request);
        }

        [HttpPost]
        public ActionResult editRequest(Request request)
        {
            edmanDBContext.Entry(request).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return View("editRequest","Success");

        }


    }
}