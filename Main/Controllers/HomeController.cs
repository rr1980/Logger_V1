using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logger_V1.Logger;
using Logger_V1.Logger.Interfaces;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        private ILogger_V1<HomeController> _logger;

        public HomeController(ILoggerService loggerService)
        {
            _logger = loggerService.CreateLogger<HomeController>();
        }

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
    }
}
