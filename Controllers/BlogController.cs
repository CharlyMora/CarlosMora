﻿using System;
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
using System.Web;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CarlosMora.Controllers
{
    public class BlogController : Controller
    {
        private readonly ICompositeViewEngine _compositeViewEngine;
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger, ICompositeViewEngine compositeViewEngine)
        {
            _compositeViewEngine = compositeViewEngine;
            _logger = logger;
        }

        public IActionResult BlogDev()
        {
            return View();
        }
        public async Task<ActionResult> Index()
        {
            var myFox = await ApiServices.FoxApi();
            // var foxLink = myFox.image;
            // if (!foxLink.StartsWith("http"))
            // {   
            //     ViewBag.foxtext= "no link for this one";
            // }else{
            //     ViewBag.foxtext = foxLink;
            // }
            return View(myFox);
        }

        public IActionResult Entries(string id)
        {
            if (id == null) return Redirect("Index");

            //if redirected to Index alone the new route will be Blog/Entries/Index
            // and this will create a conflict in the browser
            //if (!id.Equals("Entrie1")) {return RedirectToAction("Index","Blog");};

            var viewName = $"~/Views/Blog/{id}.cshtml";
            var result = _compositeViewEngine.GetView("", viewName, false);

            if (result.Success) return View(id);

            return View("MyNotFound");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
