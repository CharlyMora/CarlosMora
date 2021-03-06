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
using System.Text.Json;

namespace CarlosMora.Models
{
    public class ApiServices
    {
        private static readonly HttpClient myHttpClient = new HttpClient();
        public static async Task apiMain()
        {
            await ProcessRepositories();
        }
        public static async Task<List<repo>> ProcessRepositories()
        {
            myHttpClient.DefaultRequestHeaders.Accept.Clear();
            myHttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            myHttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            // var stringTask = myHttpClient.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            //var msg = await stringTask;
            // replaced with
            var streamTask = myHttpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            
            
            var repositories = await JsonSerializer.DeserializeAsync<List<repo>>(await streamTask);
            
            return repositories;

            // end of replacement
        }

        public static async Task<fox> FoxApi()
        {
            fox myFox = null;
            HttpResponseMessage response = await myHttpClient.GetAsync("https://randomfox.ca/floof/");
            if (response.IsSuccessStatusCode)
            //if(false) //for test purposes
            {
                
                myFox = await response.Content.ReadAsAsync<fox>();
                myFox.LinkText= myFox.image;
            }else{
                myFox = new fox{image="/imgs/dog.jpg", LinkText= "no link for this one"};
            }
            return myFox;
        }

        public static async Task<string> BirdsApi()
        {
            string[] myArray = null;
            string myLink=null;
            HttpResponseMessage response = await myHttpClient.GetAsync("http://shibe.online/api/birds");
            if (response.IsSuccessStatusCode)
            //if(false) //for test purposes
            {
                myArray = await response.Content.ReadAsAsync<string[]>();
                myLink = myArray.First();
                return myLink;
            }else{
                return "/imgs/bird.jpg";
            }
        }
    }
}