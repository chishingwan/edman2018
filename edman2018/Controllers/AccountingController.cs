using System;
using System.Collections.Generic;
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
            return View();
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