using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logger_V1.Logger;
using Logger_V1.Logger.Interfaces;
using System.Diagnostics;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        private ILogger_V1<HomeController> _logger;

        public HomeController(ILoggerService loggerService)
        {
            _logger = loggerService.CreateLogger<HomeController>();

            _logger.Log("HomeController");
        }

        public IActionResult Index()
        {
            throw new Exception("HomeController ERROR!");
#pragma warning disable CS0162 // Unerreichbarer Code wurde entdeckt.
            return View();
#pragma warning restore CS0162 // Unerreichbarer Code wurde entdeckt.
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
