using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ChatRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRHost.Datas;
using SignalRHost.Models;

namespace SignalRHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login(string account, string password)
        {
            dynamic data = new System.Dynamic.ExpandoObject(); //动态类型字段 可读可写
            var aaaa = CentralizedData.Instance.UserList.Where(x => x.Account == account && x.Password == password).FirstOrDefault();
            if(aaaa!= null)
            {
                data.Id = aaaa.Id;
                data.Name = aaaa.Name;
                ClientInfoModel model = new ClientInfoModel();
                model.Id = aaaa.Id;
                model.Name = aaaa.Name;
                //return Json(new { Success = true, Messages = "登录成功", Data = JsonSerializer.Serialize(model) });
                return Json(new { Success = true, Messages = "登录成功", Data = model });
            }
            return Json(new { Success = false, Messages = "登录失败" });
        }
    }
}
