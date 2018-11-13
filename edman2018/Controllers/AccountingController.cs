using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using edman2018.Models;
using edman2018.Reports;

namespace edman2018.Controllers
{
    public class AccountingController : Controller
    {
        EdmanDBContext edmanDBContext = new EdmanDBContext();
        // GET: Accounting
        public ActionResult Index()
        {

            AccountingViewModel accountingViewModel = new AccountingViewModel();
            accountingViewModel.TopOrder = (from p in edmanDBContext.Products
                                            join o in edmanDBContext.Order_Details
                                            on p.Product_ID equals o.Product_ID into subs
                                            from sub in subs.DefaultIfEmpty()
                                            group sub by new {p.Product_Name, p.Product_ID } into r
                                            select new AccountingViewModel.TOrders
                                            {
                                                Product_ID = r.Key.Product_ID,
                                                Product_Name = r.Key.Product_Name,
                                                Total_Orders = r.Sum(s => s !=null? s.Quantity : 0)
                                                
                                            }).OrderByDescending(x => x.Total_Orders).Take(5).ToList();
            foreach(AccountingViewModel.TOrders torders in accountingViewModel.TopOrder)
            {
                Debug.WriteLine("ID" + torders.Product_ID.ToString() + " : " + "NAME" + torders.Product_Name + " : " + "TOTAL" + torders.Total_Orders.ToString());
            }

            return View(accountingViewModel);
        }

        public ActionResult printRequestReport()
        {
            List<Request> requests = edmanDBContext.Requests.ToList();

            CrystalReport1 crystalReport1 = new CrystalReport1();
            
            crystalReport1.SetDataSource(requests);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = crystalReport1.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "RequestList.pdf");

        }



    }
}