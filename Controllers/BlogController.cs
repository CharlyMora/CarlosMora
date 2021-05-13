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

namespace CarlosMora.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult BlogDev()
        {
            return View();
        }
        public async Task<ActionResult>  Index()
        {
            var myRepos = await ApiServices.ProcessRepositories2();
            return View(myRepos);
        }

        public IActionResult Entries(string id)
        {
            if (id==null) return Redirect("Index");

            if (!id.Equals("Entrie1")) {return RedirectToAction("Index","Blog");};

            //validar con lista o base de datos que exista la vista
            //o ver como se pueden gestionar los articulos 
            //teniendo en cuenta que tienen estructuras un poco diferentes en terminos
            //de titulos y listas enumeradas etc
            // por ende no se pueden guardar como un modelo de la misma manera

            
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
