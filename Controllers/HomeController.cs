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

        // public IActionResult Blog()
        // {

        //     return View();
        // }

        public async Task<ActionResult> Blog()
        {

            var myRepos = await ApiServices.ProcessRepositories2();

            return View(myRepos);
        }

        public IActionResult BlogDev()
        {
            return View();
        }
        public IActionResult Curriculum()
        {
            return View();
        }

        public async Task<ActionResult> InspirationPages()
        {
            ViewBag.bird = await ApiServices.ProcessRepositories3();
            //var myPages = new InspirationsList();
            var myPages = new InspirationsList().myArrayOfPages;
            return View(myPages);
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult MyNotFound()
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
