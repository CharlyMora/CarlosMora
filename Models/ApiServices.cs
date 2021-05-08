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

namespace CarlosMora.Models
{
    public class ApiServices
    {
        static HttpClient client = new HttpClient();
         static async Task<string> GetImgAsync(string path)
        {
            string product = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }
    }
}