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
            var myRepos = await ApiServices.ProcessRepositories2();
            return View(myRepos);
        }

        public IActionResult Entries(string id)
        {
            if (id == null) return Redirect("Index");

            //if redirected to Index alone the new route will be Blog/Entries/Index
            // and this will create a conflict in the browser
            //if (!id.Equals("Entrie1")) {return RedirectToAction("Index","Blog");};

            //validar con lista o base de datos que exista la vista
            //o ver como se pueden gestionar los articulos 
            //teniendo en cuenta que tienen estructuras un poco diferentes en terminos
            //de titulos y listas enumeradas etc
            // por ende no se pueden guardar como un modelo de la misma manera
            var viewName = $"~/Views/Blog/{id}.cshtml";
            var result = _compositeViewEngine.GetView("", viewName, false);

            if (result.Success) return View(id);

            return RedirectToAction("MyNotFound","Home");
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
