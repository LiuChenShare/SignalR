using SignalRChat_MVC.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }


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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetResult()
        {
            var path = Server.MapPath("\\config.json");
            return Json(new { Success = true, Messages = "Success", Data = path });
        }

        [HttpGet]
        public JsonResult GetOldMessage()
        {
            var result = ChatMessageData.Instance.GetList();
            return Json(new { Success = true, Messages = "Success", Data = result },JsonRequestBehavior.AllowGet);
        }
    }
}