using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_Example.DAL;

namespace ADO_Example.Controllers
{
    public class ProductController : Controller
    {   Product_DAL _productDAL = new Product_DAL();

        // GET: Product
        public ActionResult Index()
        {
            var productList = _productDAL.GetAllProducts();

            if(productList.Count == 0)
            {
                TempData["InfoMessage"] = "Currenty product are not available in database.";
            }
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductController product)
        {
            bool IsInserted = false;

            if (ModelState.IsValid)
            {

                IsInserted = _productDAL.InsertProduct(product);

                if (IsInserted)
                {
                    TempData["successMessage"] = "Product Details Saves Succesfully......!";
                }
                else
                {
                    TempData["errorMessage"] = "Unable To Save The Product Detail";
                }
            }
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
