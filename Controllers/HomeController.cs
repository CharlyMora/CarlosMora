using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarlosMora.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CarlosMora.Controllers
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

    
        public IActionResult Curriculum()
        {
            return View();
        }

        public async Task<ActionResult> InspirationPages()
        {
            var birdLink = await ApiServices.BirdsApi();
            if (!birdLink.StartsWith("http"))
            {   ViewBag.birdLink= birdLink;
                ViewBag.birdtext= "no link for this one";
            }else{
                ViewBag.birdLink =ViewBag.birdtext = birdLink;
            }
            
            var myPages = new InspirationsList().myArrayOfPages;
            return View(myPages);
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult MyNotFound()
        {
            return View("MyNotFound");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
