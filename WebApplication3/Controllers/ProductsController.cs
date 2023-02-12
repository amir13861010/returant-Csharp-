using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext db = new MyDbContext();
        [HttpGet]
       public ActionResult Index()
        {
            return View(db.Products. OrderBy(p=>p.Row).ToList());
        }
//------------------------------------------------------------------------------------------------------------------

[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(Guid id)
        {
        try{
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return Json(new { isErr = false });
            } catch {
                return Json(new { isErr = true });
            }
        }
        [HttpGet]
        public ActionResult GetProducts(Guid id) {
            if (id == null)
                return PartialView("ItemPartial", new Products());
            var products = db.Products.Find(id);
            if(products == null)
                return PartialView("ItemPartial", new Products());
            return PartialView("ItemPartial",products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ProductsItem(Products products) {
            if (ModelState.IsValid) {
               if(db.Products.Any (p=>p.Id == products .Id)) {
                    db.Entry<Products>(products ).State =EntityState.Modified;
                    db.SaveChanges();
                } else {
                    db.Products.Add(products );
                    db.SaveChanges();
                }
                return Json(new { isOk = true } ,   JsonRequestBehavior.AllowGet );
            } else
                return Json(new { isOk=false, errs= ModelState.Values.SelectMany(v => v.Errors) } ,   JsonRequestBehavior.AllowGet );
        }
    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
