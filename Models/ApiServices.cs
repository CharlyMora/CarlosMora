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
        string myUrl = "https://thatcopy.pw/catapi/rest/";
         static async Task<string> GetImgAsync(string path)
        {
            IEnumerable<string> product= new List<string>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                // product = await response.Content.Headers.GetValues("u");
                
                                                        // .Find(x => x.Name == "userId")
                                                        // .Value.ToString();
            }
            return product.FirstOrDefault();
        }
    }
}