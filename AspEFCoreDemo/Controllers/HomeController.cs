using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Redis;
using System.Text;

namespace AspEFCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignCache(string cacheValueName, string cacheValue)
        {
            var valueToStore = Encoding.UTF8.GetBytes(cacheValue);
            HttpContext.Session.Set(cacheValueName, valueToStore);
            return Content("Cache saved");
        }
        [HttpPost]
        public IActionResult GetCache(string cacheValueName)
        {
            
            var cacheValue = default(byte []);
            if (HttpContext.Session.TryGetValue(cacheValueName, out cacheValue))
            {
                ViewBag.cacheValueName = cacheValueName;
                ViewBag.cacheValue = Encoding.UTF8.GetString(cacheValue);
                return View();
            }
            else
                return Content("object not found");

        }
    }
}
