using MVC_Prices2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Prices2.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Deneme()
        {
            using (PriceDataModel2 db = new PriceDataModel2())
            {

                int id = 1;
                var product = db.Products.FirstOrDefault(a => a.Id == id);
                

                return View(product);
            }

        }
        public JsonResult Datas(int? id = 0)
        {
            
            PriceDataModel2 db = new PriceDataModel2();

            var prices = db.Prices.Where(p => p.ProductId == id && p.Activity == true ).ToList();
            //double[,] priceMatris = new double[21, 23];
            ////foreach (var item in prices)
            ////{
            ////    for (int boy = 5; boy < 21; boy++) 
            ////    {
            ////        for (int en = 6; en < 23; en++)
            ////        {
            ////            if (item.Height == boy*100 && item.Width == en*100)
            ////            {
            ////                priceMatris[boy, en] = Convert.ToDouble(item.Prices);
            ////            }
            ////        }
            ////    }
            ////}
            return Json(prices,JsonRequestBehavior.AllowGet);


        }
    }
}