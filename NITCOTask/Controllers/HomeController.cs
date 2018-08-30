using NITCOTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NITCOTask.Controllers
{
    public class HomeController : Controller
    {
        NITCOEntities lm = new NITCOEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Order()
        {
            //SelectList MyList = new SelectList(db.Categories, "id", "Category_name");

            ViewBag.names = new SelectList(lm.Categories.ToList(),"Id","name");

            //to Add A GUID to resetId textBox
            //ViewBag.resetId = Guid.NewGuid();
           
            // to Add 1 after the id value in database
            int key = 1;
            //ViewBag.resetId = lm.ResetHeaders.Where(a => a.Id==3).Select(a=>a.Id).Single() + key ;
           
              ViewBag.resetId =  lm.ResetHeaders.OrderByDescending(a => a.Id).FirstOrDefault().Id + key;
            
            return View();
        }

        [HttpPost]
        public ActionResult ProTypes(int? id)
        {
            var qq = new SelectList(lm.Products.Where(x => x.categoryId == id),"Id","name");
            return Json(qq) ;
        }

        // For ResetId
        //[HttpPost]//3 2 1 
        //public ActionResult ResetNumber()
        //{
        //    var resetNumber = lm.ResetHeaders.OrderByDescending(a => a.Id).FirstOrDefault().Id;
        //    return Json(new { resN = resetNumber });
        //}


        [HttpPost]
        public ActionResult price(int id)
        {
            var qq = lm.Products.FirstOrDefault(a =>  a.id == id).price;
            return Json(new { price = qq });
        }

    }
}