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
    public class BlogEntriesController : Controller
    {
        // private readonly ILogger<BlogEntriesController> _logger;


        // public BlogEntriesController(ILogger<BlogEntriesController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult BlogDev()
        {
            return View();
        }

        public IActionResult Entrie(string id)
        {
            
            return View(id);
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
