using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edman2018.Models;

namespace edman2018.Controllers
{
    public class SalesController : Controller
    {

        EdmanDBContext edmanDBContext = new EdmanDBContext();

        // GET: Sales
        public ActionResult Index()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.products = edmanDBContext.Products.ToList();
            salesViewModel.returns = edmanDBContext.Returns.ToList();
            return View(salesViewModel);
        }

        /**
         
         ADD, EDIT, DELETE, VIEW Products

        VIEW, EDIT RETURNS

        ADD REVIEW
         
         */
         

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string Product_Name, int Price, string Product_Description, HttpPostedFileBase photo)
        {
            Product product = new Product();
            product.Product_Name = Product_Name;
            product.Price = Price;
            product.Product_Description = Product_Description;
            product.Date_Added = DateTime.Now;
            product.Date_Modified = DateTime.Now;
            product.Available = "Yes";
            product.Critical_Level = 0;
            edmanDBContext.Products.Add(product);
            edmanDBContext.SaveChanges();

            System.Diagnostics.Debug.WriteLine("Upload Start");

            if (photo != null)
            {

                System.Diagnostics.Debug.WriteLine("Uploading");
                string pic = product.Product_ID.ToString() + Path.GetExtension(photo.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/product"), pic);
                // file is uploaded
                photo.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB

            }

            return new RedirectResult(Url.Action("Index") + "#products");
        }

        public ActionResult viewProducts()
        {
            List<Product> products = edmanDBContext.Products.ToList();
            return View(products);
        }
        public ActionResult viewProduct(int Product_ID)
        {
            Product product = edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).First();
            return View(product);
        }

        public ActionResult EditProduct(int Product_ID)
        {
            Product product = edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).First();
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            edmanDBContext.Entry(product).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return View("editProduct","Success");
        }

        public ActionResult DeleteProduct(int Product_ID)
        {
            edmanDBContext.Products.Remove(edmanDBContext.Products.Where(p => p.Product_ID == Product_ID).First());
            edmanDBContext.SaveChanges();
            return new RedirectResult(Url.Action("Index") + "#products");
        }

        [HttpPost]
        public ActionResult AddComment(Review review)
        {
            edmanDBContext.Reviews.Add(review);
            edmanDBContext.SaveChanges();
            return View(review.Product_ID);
        }

        public ActionResult viewReturns()
        {
            List<Return> returns = edmanDBContext.Returns.ToList();
            return View(returns);
        }

        public ActionResult AcceptReturn(int Return_ID)
        {
            Return return1 = edmanDBContext.Returns.Where(r => r.Return_ID == Return_ID).First();
            return View(return1);
        }

        [HttpPost]
        public ActionResult AcceptReturn(Return return1)
        {
            edmanDBContext.Entry(return1).State = EntityState.Modified;
            edmanDBContext.SaveChanges();
            return View("editReturn", "Success");
        }

    }
}