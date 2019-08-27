using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OceletGateWay.Models;
using Ocelot.Logging;

namespace OceletGateWay.Controllers
{
    public class HomeController : Controller
    {
        public IOcelotLoggerFactory Logger { get; set; }

        public IOcelotLogger log;

        public HomeController(IOcelotLoggerFactory logger)
        {
            Logger = logger;
            log = Logger.CreateLogger<string>();
        }

        public IActionResult Index()
        {
            log.LogInformation("*********Start*************");
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
    }
}